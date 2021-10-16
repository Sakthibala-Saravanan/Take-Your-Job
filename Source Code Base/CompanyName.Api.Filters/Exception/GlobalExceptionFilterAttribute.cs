using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using AspireSystems.Diagnostics.ErrorHandler;
using AspireSystems.Diagnostics.Exceptions;
using AspireSystems.Infrastructure.Helpers;

namespace AspireSystems.Api.Filters.Exception
{
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        #region Members
        public IAspireSystemsExceptionHandler ExceptionHandler { get; set; }
        #endregion

        #region Constructor
        public GlobalExceptionFilterAttribute(IAspireSystemsExceptionHandler exceptionHandler)
        {
            ExceptionHandler = exceptionHandler;
        }
        #endregion

        #region Overriden Method
        public override void OnException(ExceptionContext context)
        {
            // Handle each exception type and log, return response accordingly
            if (context.Exception is UnauthorizedAccessException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (context.Exception is ApiException)
            {
                // Model validation errors are handled here
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception is ServiceException)
            {
                // Service level exceptions with additional custom data to be logged here
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var exception = context.Exception;
                context.Result = new ContentResult
                {
                    Content = $"Error: {exception.Message}",
                    ContentType = "text/plain",
                };
            }
            else if (context.Exception is RepositoryException)
            {
                // Repository level exceptions with additional custom data to be logged here
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var content = string.Empty;
            if (context.HttpContext.Request.ContentType.Equals("application/json", StringComparison.OrdinalIgnoreCase))
            {
                //reading content from request
            }
            //Logging exception details using log4net
            ExceptionHandler.HandleException(context.Exception, UserIdentity.UserName, context.HttpContext.Request.Path, content);          

            // Return error response with details
            context.Result = new JsonResult(context.Exception);
            base.OnException(context);
        }
        #endregion Overriden Methods
    }
}