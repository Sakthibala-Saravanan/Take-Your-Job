using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Net.Http.Headers;
using AspireSystems.TakeYourJob.WebApi;

namespace AspireSystems.TakeYourJob.WebApi.IntegrationTest.Core.Client
{
    /// <summary>
    /// Client Class that builds HTTPClient
    /// </summary>
    class ApiClient
    {
        #region Variable
        public HttpClient httpClient { get; private set; }
        #endregion Variable

        #region Constructor
        public ApiClient()
        {
            var ProductNamer = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            httpClient = ProductNamer.CreateClient();
        }

        public ApiClient(string token)
        {
            var ProductNamer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            httpClient = ProductNamer.CreateClient();
            SetHeader(token);
        }
        #endregion Constructor

        #region Private Methods
        /// <summary>
        /// Method to set headers for Api
        /// </summary>
        /// <param name="jwtToken"></param>
        private void SetHeader(string jwtToken)
        {
            httpClient.DefaultRequestHeaders.Accept
               .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var token = string.Concat("Bearer ", jwtToken);
            httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Authorization", token);
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }
        #endregion Private Methods
    }
}