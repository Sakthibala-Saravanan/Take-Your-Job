using AspireSystems.Diagnostics.Enums;

namespace AspireSystems.Diagnostics.Errors.Base
{
    public class BaseError
    {
        /// <summary>
        /// Category of the error viz., application/validation etc.,
        /// </summary>
        public ErrorCategory Category { get; set; }
        /// <summary>
        /// Custom error message
        /// </summary>
        public string Message { get; set; }
    }
}
