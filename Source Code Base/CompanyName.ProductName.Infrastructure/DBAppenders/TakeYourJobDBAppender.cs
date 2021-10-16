using log4net.Appender;
using log4net.Core;
using log4net.Util;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace AspireSystems.TakeYourJob.Infrastructure.DBAppenders
{
	public class TakeYourJobDBAppender : BufferingAppenderSkeleton
	{
		#region Constructors
		public TakeYourJobDBAppender()
		{
			ConnectionType = typeof(SqlConnection).AssemblyQualifiedName;
			_lazyConnectionTypeResolve = new Lazy<Type>(LazyResolveConnectionType);
			UseTransactions = true;
			CommandType = System.Data.CommandType.Text;
			_parameters = new ArrayList();
			ReconnectOnError = false;
		}
		#endregion

		#region Protected Fields
		protected ArrayList _parameters;
		#endregion

		#region Private Fields
		private SecurityContext _securityContext;
		private IDbConnection _dbConnection;
		private string _connectionString;
		private string _appSettingsKey;
		//#if NET_2_0 || NETSTANDARD
		private string _connectionStringName;
		//#endif
		//#if NETSTANDARD
		private string _connectionStringFile;
		//#endif
		private string _connectionType;
		private string _commandText;
		private CommandType _commandType;
		private bool _useTransactions;
		private bool _reconnectOnError;
		#endregion

		#region Private Static Fields
		private readonly static Type declaringType = typeof(TakeYourJobDBAppender);
		private readonly Lazy<Type> _lazyConnectionTypeResolve;
		#endregion

		#region Public Properties
		public string ConnectionString
		{
			get { return _connectionString; }
			set { _connectionString = value; }
		}

		public string AppSettingsKey
		{
			get { return _appSettingsKey; }
			set { _appSettingsKey = value; }
		}

		//#if NET_2_0 || NETSTANDARD
		public string ConnectionStringName
		{
			get { return _connectionStringName; }
			set { _connectionStringName = value; }
		}
		//#endif
		//#if NETSTANDARD
		public string ConnectionStringFile
		{
			get { return _connectionStringFile; }
			set { _connectionStringFile = value; }
		}
		//#endif

		public string ConnectionType
		{
			get { return _connectionType; }
			set { _connectionType = value; }
		}

		public string CommandText
		{
			get { return _commandText; }
			set { _commandText = value; }
		}

		public CommandType CommandType
		{
			get { return _commandType; }
			set { _commandType = value; }
		}

		public bool UseTransactions
		{
			get { return _useTransactions; }
			set { _useTransactions = value; }
		}

		public SecurityContext SecurityContext
		{
			get { return _securityContext; }
			set { _securityContext = value; }
		}

		public bool ReconnectOnError
		{
			get { return _reconnectOnError; }
			set { _reconnectOnError = value; }
		}
		#endregion

		#region Protected Properties
		protected IDbConnection Connection
		{
			get { return _dbConnection; }
			set { _dbConnection = value; }
		}
		#endregion

		#region Implementation of IOptionHandler
		override public void ActivateOptions()
		{
			base.ActivateOptions();

			if (SecurityContext == null)
			{
				SecurityContext = SecurityContextProvider.DefaultProvider.CreateSecurityContext(this);
			}

			InitializeDatabaseConnection();
		}
		#endregion

		#region Override implementation of AppenderSkeleton
		override protected void OnClose()
		{
			base.OnClose();
			DiposeConnection();
		}
		#endregion

		#region Override implementation of BufferingAppenderSkeleton
		override protected void SendBuffer(LoggingEvent[] events)
		{
			if (ReconnectOnError && (Connection == null || Connection.State != ConnectionState.Open))
			{
				LogLog.Debug(declaringType, "Attempting to reconnect to database. Current Connection State: " + ((Connection == null) ? SystemInfo.NullText : Connection.State.ToString()));

				InitializeDatabaseConnection();
			}

			// Check that the connection exists and is open
			if (Connection != null && Connection.State == ConnectionState.Open)
			{
				if (UseTransactions)
				{
					// Create transaction
					// NJC - Do this on 2 lines because it can confuse the debugger
					using (IDbTransaction dbTran = Connection.BeginTransaction())
					{
						try
						{
							SendBuffer(dbTran, events);

							// commit transaction
							dbTran.Commit();
						}
						catch (Exception ex)
						{
							// rollback the transaction
							try
							{
								dbTran.Rollback();
							}
							catch (Exception)
							{
								// Ignore exception
							}

							// Can't insert into the database. That's a bad thing
							ErrorHandler.Error("Exception while writing to database", ex);
						}
					}
				}
				else
				{
					// Send without transaction
					SendBuffer(null, events);
				}
			}
		}
		#endregion

		#region Public Methods
		public void AddParameter(TakeYourJobDBAppenderParameter parameter)
		{
			_parameters.Add(parameter);
		}
		#endregion

		#region Protected Methods
		virtual protected void SendBuffer(IDbTransaction dbTran, LoggingEvent[] events)
		{
			// string.IsNotNullOrWhiteSpace() does not exist in ancient .NET frameworks
			if (CommandText != null && CommandText.Trim() != "")
			{
				using (IDbCommand dbCmd = Connection.CreateCommand())
				{
					// Set the command string
					dbCmd.CommandText = CommandText;

					// Set the command type
					dbCmd.CommandType = CommandType;
					// Send buffer using the prepared command object
					if (dbTran != null)
					{
						dbCmd.Transaction = dbTran;
					}
					// prepare the command, which is significantly faster
					dbCmd.Prepare();
					// run for all events
					foreach (LoggingEvent e in events)
					{
						// clear parameters that have been set
						dbCmd.Parameters.Clear();

						// Set the parameter values
						foreach (TakeYourJobDBAppenderParameter param in _parameters)
						{
							param.Prepare(dbCmd);
							param.FormatValue(dbCmd, e);
						}

						// Execute the query
						dbCmd.ExecuteNonQuery();
					}
				}
			}
			else
			{
				// create a new command
				using (IDbCommand dbCmd = Connection.CreateCommand())
				{
					if (dbTran != null)
					{
						dbCmd.Transaction = dbTran;
					}
					// run for all events
					foreach (LoggingEvent e in events)
					{
						// Get the command text from the Layout
						string logStatement = GetLogStatement(e);

						LogLog.Debug(declaringType, "LogStatement [" + logStatement + "]");

						dbCmd.CommandText = logStatement;
						dbCmd.ExecuteNonQuery();
					}
				}
			}
		}

		virtual protected string GetLogStatement(LoggingEvent logEvent)
		{
			if (Layout == null)
			{
				ErrorHandler.Error("AdoNetAppender: No Layout specified.");
				return "";
			}
			else
			{
				StringWriter writer = new StringWriter(System.Globalization.CultureInfo.InvariantCulture);
				Layout.Format(writer, logEvent);
				return writer.ToString();
			}
		}

		virtual protected IDbConnection CreateConnection(Type connectionType, string connectionString)
		{
			IDbConnection connection = (IDbConnection)Activator.CreateInstance(connectionType);
			connection.ConnectionString = connectionString;
			return connection;
		}

		virtual protected string ResolveConnectionString(out string connectionStringContext)
		{
			if (ConnectionString != null && ConnectionString.Length > 0)
			{
				connectionStringContext = "ConnectionString";
				return ConnectionString;
			}

			//#if NET_2_0
			//if (!String.IsNullOrEmpty(ConnectionStringName))
			//{
			//	ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[ConnectionStringName];
			//	if (settings != null)
			//	{
			//		connectionStringContext = "ConnectionStringName";
			//		return settings.ConnectionString;
			//	}
			//	else
			//	{
			//		throw new LogException("Unable to find [" + ConnectionStringName + "] ConfigurationManager.ConnectionStrings item");
			//	}
			//}
			//#endif
			//#if NETSTANDARD
			if (!string.IsNullOrWhiteSpace(ConnectionStringFile))
			{
				var configFile = new FileInfo(ConnectionStringFile);
				if (configFile.Exists)
				{
					var configurationBuilder = new ConfigurationBuilder();
					if (configFile.Extension.ToLowerInvariant() == ".json")
					{
						configurationBuilder.AddJsonFile(configFile.FullName, false);
					}
					else
					{
						throw new LogException($"Unsupported configuration format \"{configFile.Extension}\"");
					}
					var configuration = configurationBuilder.Build();
					connectionStringContext = $"ConnectionStringFile: {configFile.FullName}";
					return configuration.GetConnectionString(ConnectionStringName);
				}
				throw new LogException($"Unable to find [{ConnectionStringFile}] at \"{configFile.FullName}\"");
			}
			//#endif

			if (AppSettingsKey != null && AppSettingsKey.Length > 0)
			{
				connectionStringContext = "AppSettingsKey";
				string appSettingsConnectionString = SystemInfo.GetAppSetting(AppSettingsKey);
				if (appSettingsConnectionString == null || appSettingsConnectionString.Length == 0)
				{
					throw new LogException("Unable to find [" + AppSettingsKey + "] AppSettings key.");
				}
				return appSettingsConnectionString;
			}

			connectionStringContext = "Unable to resolve connection string from ConnectionString, ConnectionStrings, or AppSettings.";
			return string.Empty;
		}

		virtual protected Type ResolveConnectionType()
		{
			try
			{
				return _lazyConnectionTypeResolve.Value;
			}
			catch (Exception ex)
			{
				ErrorHandler.Error("Failed to load connection type [" + ConnectionType + "]", ex);
				throw;
			}
		}
		#endregion

		#region Private Methods
		private Type LazyResolveConnectionType()
		{
#if NETSTANDARD
            return SystemInfo.GetTypeFromString(GetType().GetTypeInfo().Assembly, ConnectionType, true, false);
#else
			return SystemInfo.GetTypeFromString(GetType().Assembly, ConnectionType, true, false);
#endif
		}

		private void InitializeDatabaseConnection()
		{
			string connectionStringContext = "Unable to determine connection string context.";
			string resolvedConnectionString = string.Empty;

			try
			{
				DiposeConnection();

				// Set the connection string
				resolvedConnectionString = ResolveConnectionString(out connectionStringContext);

				Connection = CreateConnection(ResolveConnectionType(), resolvedConnectionString);

				using (SecurityContext.Impersonate(this))
				{
					// Open the database connection
					Connection.Open();
				}
			}
			catch (Exception e)
			{
				// Sadly, your connection string is bad.
				ErrorHandler.Error("Could not open database connection [" + resolvedConnectionString + "]. Connection string context [" + connectionStringContext + "].", e);

				Connection = null;
			}
		}

		private void DiposeConnection()
		{
			if (Connection != null)
			{
				try
				{
					Connection.Close();
				}
				catch (Exception ex)
				{
					LogLog.Warn(declaringType, "Exception while disposing cached connection object", ex);
				}
				Connection = null;
			}
		}
		#endregion
	}
}
