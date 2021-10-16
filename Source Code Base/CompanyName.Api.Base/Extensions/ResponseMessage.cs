using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using AspireSystems.Api.Base.Constants;
using AspireSystems.Api.Base.Responses;
using AspireSystems.Api.Base.Responses.Contracts;

namespace AspireSystems.Api.Base.Extensions
{
    public static class AspireSystemsResponseMessage
    {
        #region Members
        
        /// <summary>
        /// Media type header for Json responses
        /// </summary>
        private const string JsonMediaTypeHeader = "text/json";

        #endregion Members

        #region Public Methods

        /// <summary>
        /// Response with Status code = 200 and content in CompanyName API response format
        /// </summary>
        /// <param name="CompanyNameMessage"></param>
        /// <returns></returns>
        public static HttpResponseMessage Ok(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage)
        {
            return GetMessage(statusCode: HttpStatusCode.OK);
        }

        /// <summary>
        /// Response with Status code = 200 and content in CompanyName API response format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CompanyNameMessage"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static HttpResponseMessage Ok<T>(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage, T content)
        {
            return GetMessage(statusCode: HttpStatusCode.OK
                , content: content);
        }

        /// <summary>
        /// Response with given status code and content in CompanyName API response format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CompanyNameMessage"></param>
        /// <param name="statusCode"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static HttpResponseMessage Content<T>(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage, HttpStatusCode statusCode, T value)
        {
            return GetMessage(statusCode: statusCode
                , content: value);
        }

        /// <summary>
        /// Response with Status code = 200 and content in CompanyName API response format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CompanyNameMessage"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static HttpResponseMessage Json<T>(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage, T content)
        {
            return GetMessage(statusCode: HttpStatusCode.OK
                , content: content);
        }

        /// <summary>
        /// Response with Status code = 201 and content in CompanyName API response format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CompanyNameMessage"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static HttpResponseMessage Created<T>(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage, T content)
        {
            return GetMessage(statusCode: HttpStatusCode.Created
                , content: content);
        }

        /// <summary>
        /// Response with Status code = 204 and content in CompanyName API response format
        /// </summary>
        /// <param name="CompanyNameMessage"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static HttpResponseMessage NoContent(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage
            , string message = null)
        {
            return GetMessage(statusCode: HttpStatusCode.NoContent
                , message: message ?? MessageString.NoContent);
        }

        /// <summary>
        /// Response with Status code = 400 and content in CompanyName API response format
        /// </summary>
        /// <param name="CompanyNameMessage"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static HttpResponseMessage BadRequest(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage
            , string message = null, Exception exception = null)
        {
            return GetMessage(statusCode: HttpStatusCode.BadRequest
                , message: message ?? MessageString.BadRequest, exceptionInfo: exception);
        }

        /// <summary>
        /// Response with Status code = 401 and content in CompanyName API response format
        /// </summary>
        /// <param name="CompanyNameMessage"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static HttpResponseMessage Unauthorized(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage
            , string message = null, Exception exception = null)
        {
            return GetMessage(statusCode: HttpStatusCode.Unauthorized
                , message: message ?? MessageString.UnauthorizedAccess, exceptionInfo: exception);
        }

        /// <summary>
        /// Response with Status code = 404 and content in CompanyName API response format
        /// </summary>
        /// <param name="CompanyNameMessage"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static HttpResponseMessage NotFound(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage
            , string message = null)
        {
            return GetMessage(statusCode: HttpStatusCode.NotFound
                , message: message ?? MessageString.NotFound);
        }

        /// <summary>
        /// Response with Status code = 409 and content in CompanyName API response format
        /// </summary>
        /// <param name="CompanyNameMessage"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static HttpResponseMessage Conflict(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage
            , string message = null)
        {
            return GetMessage(statusCode: HttpStatusCode.Conflict
                , message: message ?? MessageString.Conflict);
        }

        /// <summary>
        /// Response with Status code = 500 and content in CompanyName API response format
        /// </summary>
        /// <param name="CompanyNameMessage"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static HttpResponseMessage InternalServerError(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage
            , string message = null, Exception exception = null)
        {
            return GetMessage(statusCode: HttpStatusCode.InternalServerError
                , message: message ?? MessageString.ServerError, exceptionInfo: exception);
        }

        /// <summary>
        /// Response with given status code and content in CompanyName API response format
        /// </summary>
        /// <param name="CompanyNameMessage"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static HttpResponseMessage StatusCode(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage
            , HttpStatusCode statusCode)
        {
            return GetMessage(statusCode: statusCode);
        }

        #region Not Implemented extensions

        public static HttpResponseMessage Json<T>(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage, T content, JsonSerializerSettings serializerSettings)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage Json<T>(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage, T content, JsonSerializerSettings serializerSettings, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage Redirect(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage, string location)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage Redirect(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage, Uri location)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage RedirectToRoute(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage, string routeName, IDictionary<string, object> routeValues)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage RedirectToRoute(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage, string routeName, object routeValues)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage Unauthorized(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage, IEnumerable<AuthenticationHeaderValue> challenges)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage Unauthorized(this IAspireSystemsApiMessage<IAspireSystemsApiResponse> CompanyNameMessage, params AuthenticationHeaderValue[] challenges)
        {
            throw new NotImplementedException();
        }

        #endregion Not Implemented extensions

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Encapsulate HttpResponse with data and error details formatted as CompanyNameApiResponse
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="content"></param>
        /// <param name="exceptionInfo"></param>
        /// <returns></returns>
        private static HttpResponseMessage GetMessage(HttpStatusCode statusCode, string message = null
            , object content = null, Exception exceptionInfo = null)
        {
            // Initialize an HttpResponseMessage object
            var response = new HttpResponseMessage();
            response.StatusCode = statusCode;

            Meta meta = new Meta();
            if (exceptionInfo != null)
            {
                // Add custom message strings to the meta error list
                meta.AddError(message ?? MessageString.BadRequest);

                // Add detailed exception info for troubleshooting
                meta.AddException(exceptionInfo);
            }

            // Create a CompanyNameApiResponse instance with the content, errors and status code from above
            var AspireSystemsApiResponse = new AspireSystemsApiResponse(content ?? default(object)
                , meta.HasErrors ? meta : null);

            AspireSystemsApiResponse.StatusCode = statusCode;

            // Convert the response object into Json string
            var responseJson = JsonConvert.SerializeObject(AspireSystemsApiResponse);

            // Get the HttpContent from the Json string
            var AspireSystemsApiResponseContent = new StringContent(responseJson);

            // Set the media type header value to the response
            AspireSystemsApiResponseContent.Headers.ContentType = new MediaTypeHeaderValue(JsonMediaTypeHeader);

            // Set the constructed CompanyNameApiResponse content as HttpResponse content
            response.Content = AspireSystemsApiResponseContent;

            return response;
        }

        #endregion Private Methods
    }
}
