using System;
using System.Runtime.Serialization;

namespace AspireSystems.Diagnostics.Exceptions
{
    [Serializable]
    public class ServiceException : Exception
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ServiceException class.
        /// </summary>
        public ServiceException() : base() { }
        
        /// <summary>
        /// Initializes a new instance of the ServiceException class with a specified error messge
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ServiceException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the ServiceException class with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference</param>
        public ServiceException(string message, Exception innerException) : base(message, innerException) { }
        protected ServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion Constructor
    }
}
