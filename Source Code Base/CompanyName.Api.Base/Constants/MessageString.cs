/// <summary>
/// Global response message constant strings
/// </summary>
namespace AspireSystems.Api.Base.Constants
{
    public static class MessageString
    {
        /// <summary>
        /// Default message for conflicts while creating an entity
        /// </summary>
        public const string Conflict = "An entity exists already with the same Id";
        /// <summary>
        /// Default message for internal server error
        /// </summary>
        public const string ServerError = "Server Error. Please contact Administrator";
        /// <summary>
        /// Default message for bad requests, invalid model state errors
        /// </summary>
        public const string BadRequest = "Bad request";
        /// <summary>
        /// Default message for unauthorize access error
        /// </summary>
        public const string UnauthorizedAccess = "Unauthorized access";
        /// <summary>
        /// Default message for no results found for query
        /// </summary>
        public const string NoContent = "No content found";
        /// <summary>
        /// Default message when a resource requested is not found
        /// </summary>
        public const string NotFound = "The requested resource is not found";
    }
}
