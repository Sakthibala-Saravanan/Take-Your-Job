using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AspireSystems.TakeYourJob.WebApi.IntegrationTest.Core.Client;
using AspireSystems.TakeYourJob.WebApi.IntegrationTest.Core.Helper;
using Xunit;

namespace AspireSystems.ProductName.WebApi.IntegrationTest.Core

{
    public class TestBase
    {
        #region Variables
        //private static AuthenticationApiTestData authenticationApiTestData = new AuthenticationApiTestData();
        #endregion Variables

        #region TestMethod
        /// <summary>
        /// Method to get the JWT Token
        /// </summary>
        [Fact]
        public static async Task<string> GetToken()
        {
            using (var loginClient = new ApiClient().httpClient)
            {
                //var response = await loginClient.PostAsync(Constants.authenticationUri, authenticationApiTestData.GetPostData());
                //return  response.Content.ReadAsStringAsync().Result;
                return "";
            }
        }
        #endregion
    }
}
