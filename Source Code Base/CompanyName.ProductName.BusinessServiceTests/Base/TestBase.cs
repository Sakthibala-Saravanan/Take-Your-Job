using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IO;
using AspireSystems.Infrastructure.Helpers;
using AspireSystems.TakeYourJob.BusinessServiceTests.Provider;

namespace AspireSystems.TakeYourJob.BusinessServiceTests.Base
{
    public class TestBase
    {
        protected IOptions<UTAppSettings> config;

        public TestBase()
        {
            SetDefaultUserIdentity();
        }

        private void GetAppSettings()
        {
            string jsonContent = "";
            using (StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "configs\\TestingAppSettings.json")))
            {
                jsonContent = sr.ReadToEnd();
                sr.Close();
            }
            if (!String.IsNullOrEmpty(jsonContent))
            {
                config = Options.Create<UTAppSettings>(JsonConvert.DeserializeObject<UTAppSettings>(jsonContent));
            }
        }
        protected void SetDefaultUserIdentity()
        {
            GetAppSettings();
            UserIdentity.Configure(new UnitTestingUserIdentityProvider(this.config));
        }
        protected void SetUserRole(string role)
        {
            config.Value.UTUserRoles = role;
            UserIdentity.Configure(new UnitTestingUserIdentityProvider(this.config));
        }
    }
}
