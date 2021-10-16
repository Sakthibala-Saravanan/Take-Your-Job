using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using AspireSystems.Api.Base.Responses.Contracts;


namespace AspireSystems.Api.Base.Responses
{
    public class AspireSystemsApiResponse : IAspireSystemsApiResponse
    {
        /// <summary>
        /// Error details with custom messages
        /// </summary>
        [DataMember]
        public Meta Meta { get; set; }
        /// <summary>
        /// Response content object/serializable dto content
        /// </summary>
        [DataMember]
        public object Data { get; set; }

        /// <summary>
        /// Restified status code of the Http response
        /// </summary>
        [DataMember]
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Initialize response object
        /// </summary>
        /// <param name="data"></param>
        /// <param name="meta"></param>
        /// <param name="httpStatusCode"></param>
        public AspireSystemsApiResponse(object data, Meta meta = null)
        {
            Data = data;
            Meta = meta;
        }
    }
    [Serializable]
    public class Meta
    {
        #region Constructor

        public Meta()
        {

        }

        #endregion Constructor

        /// <summary>
        /// Exceptions list
        /// </summary>
        [DataMember]
        public List<Exception> Errors { get; set; }

        /// <summary>
        /// Check if errors exist
        /// </summary>
        [DataMember]
        public bool HasErrors
        {
            get { return Errors != null && Errors.Count > 0; }
        }

        /// <summary>
        /// Add error messages to the exception list
        /// </summary>
        /// <param name="errorMessage"></param>
        public void AddError(string errorMessage)
        {
            // Initialize error list
            if (Errors == null)
            {
                Errors = new List<Exception>();
            }
            Errors.Add(new Exception(errorMessage));
        }

        /// <summary>
        /// Add details exception info to the exception list
        /// </summary>
        /// <param name="ex"></param>
        public void AddException(Exception ex)
        {
            // Initialize error list
            if (Errors == null)
            {
                Errors = new List<Exception>();
            }
            Errors.Add(ex);
        }
    }
}
