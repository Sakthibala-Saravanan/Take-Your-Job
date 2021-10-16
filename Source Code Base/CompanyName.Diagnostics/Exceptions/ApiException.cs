using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AspireSystems.Diagnostics.Errors;
using AspireSystems.Diagnostics.Errors.Base;

namespace AspireSystems.Diagnostics.Exceptions
{
    [Serializable]
    public class ApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the ApiException class.
        /// </summary>
        public ApiException() : base() { }

        /// <summary>
        /// Initializes a new instance of the ApiException class with a specified error messge
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApiException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the ApiException class with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference</param>
        public ApiException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the ApiException class with a specified error
        /// message and the error data.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="errorData">The error data list</param>
        public ApiException(string message, List<BaseError> errorData) : base(message)
        {
            // Add the custom error data to the exception
            this.Data.Add("Errors", errorData);
        }

        /// <summary>
        /// Initializes a new instance of the ApiException class with a specified error
        /// message and the validation error data.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="errorData">The validation error data list</param>
        public ApiException(string message, List<ValidationError> validationErrorData) : base(message)
        {
            // Add the custom error data to the exception
            this.Data.Add("Errors", validationErrorData);
        }
        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
