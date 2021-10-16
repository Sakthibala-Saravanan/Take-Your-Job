using log4net.Core;
using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AspireSystems.TakeYourJob.Infrastructure.DBAppenders
{
    public class TakeYourJobDBAppenderParameter
    {
        #region Constructors
        public TakeYourJobDBAppenderParameter()
        {
            Precision = 0;
            Scale = 0;
            Size = 0;
        }
        #endregion

        #region Private Members
        private string _parameterName;
        private DbType _dbType;
        private bool _inferType = true;
        private byte _precision;
        private byte _scale;
        private int _size;
        private IRawLayout _layout;
        #endregion

        #region Public Properties
        public string ParameterName
        {
            get { return _parameterName; }
            set { _parameterName = value; }
        }

        public DbType DbType
        {
            get { return _dbType; }
            set
            {
                _dbType = value;
                _inferType = false;
            }
        }

        public byte Precision
        {
            get { return _precision; }
            set { _precision = value; }
        }

        public byte Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public IRawLayout Layout
        {
            get { return _layout; }
            set { _layout = value; }
        }
        #endregion

        #region Public Methods
        virtual public void Prepare(IDbCommand command)
        {
            // Create a new parameter
            IDbDataParameter param = command.CreateParameter();

            // Set the parameter properties
            param.ParameterName = ParameterName;

            if (!_inferType)
            {
                param.DbType = DbType;
            }
            if (Precision != 0)
            {
                param.Precision = Precision;
            }
            if (Scale != 0)
            {
                param.Scale = Scale;
            }
            if (Size != 0)
            {
                param.Size = Size;
            }

            // Add the parameter to the collection of params
            command.Parameters.Add(param);
        }

        virtual public void FormatValue(IDbCommand command, LoggingEvent loggingEvent)
        {
            // Lookup the parameter
            IDbDataParameter param = (IDbDataParameter)command.Parameters[ParameterName];

            // Format the value
            object formattedValue = Layout.Format(loggingEvent);

            // If the value is null then convert to a DBNull
            if (formattedValue == null)
            {
                formattedValue = DBNull.Value;
            }

            param.Value = formattedValue;
        }
        #endregion

    }
}
