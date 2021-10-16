using AspireSystems.SqlRepository.Migrator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireSystems.SqlRepository.Migrator.Helpers
{
    class MigratorHelper
    {
        public static string GetConnectionString(CommandLineOptions commandLineOptions)
        {
            if (!string.IsNullOrEmpty(commandLineOptions.ConnectionStringValue))
            {
                Console.WriteLine("[Information]: Using the connection string value provided.");
                return commandLineOptions.ConnectionStringValue;
            }

            if (!string.IsNullOrEmpty(commandLineOptions.ConnectionStringName))
            {
                return GetConnectionStringFromConfig(commandLineOptions.ConnectionStringName);
            }

            var assembledConnectionString = AssembleConnectionStringUsingIndividualArguments(commandLineOptions);

            if (!string.IsNullOrEmpty(assembledConnectionString))
            {
                // Notice, we don't print the assembled value here (since password will be in the output).
                // However, Fluent Migrator will print with the password hidden
                Console.WriteLine("[Information]: Using assembled connection string.");
                return assembledConnectionString;
            }

            // if we still have nothing, use the default connection string name from the config
            Console.WriteLine(
                "[Information]: No other parameters provided. Will use the default connection string name");
            var defaultConnectionString = GetConnectionStringFromConfig("TestAppDbContextLocal");

            return defaultConnectionString;
        }

        public static string GetConnectionStringFromConfig(string connectionStringName)
        {
            var connectionStringVal = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (connectionStringVal == null)
            {
                Console.WriteLine(
                    "[Information]: Cannot locate a connection string with name = '{0}' in the configuration file.",
                    connectionStringName);
                return null;
            }

            Console.WriteLine(
                "[Information]: Using the connection string name with name = '{0}' in the configuration file.",
                connectionStringName);

            return connectionStringVal.ConnectionString;
        }

        public static string AssembleConnectionStringUsingIndividualArguments(CommandLineOptions commandLineOptions)
        {
            Console.WriteLine(
                "[Information]: no connection string name or value provided. Will try to assemble using other parameters");

            var builder = new SqlConnectionStringBuilder();

            if (!string.IsNullOrEmpty(commandLineOptions.Server))
            {
                builder.DataSource = commandLineOptions.Server;
            }

            if (!string.IsNullOrEmpty(commandLineOptions.Database))
            {
                builder.InitialCatalog = commandLineOptions.Database;
            }

            if (!string.IsNullOrEmpty(commandLineOptions.UserId))
            {
                builder.UserID = commandLineOptions.UserId;
            }

            if (!string.IsNullOrEmpty(commandLineOptions.Password))
            {
                builder.Password = commandLineOptions.Password;
            }

            if (commandLineOptions.Encrypt)
            {
                builder.Encrypt = true;
            }

            if (commandLineOptions.TrustServerCertificate)
            {
                builder.TrustServerCertificate = true;
            }

            return builder.ConnectionString;
        }
    }
}
