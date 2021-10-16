using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using AspireSystems.Infrastructure.Providers;
using AspireSystems.TakeYourJob.BusinessServiceTests.Base;

namespace AspireSystems.TakeYourJob.BusinessServiceTests.Provider
{
    public class UnitTestingUserIdentityProvider : IUserIdentityProvider
    {
        protected IOptions<UTAppSettings> config;

        public UnitTestingUserIdentityProvider(IOptions<UTAppSettings> _config)
        {
            this.config = _config;
        }

        public string UserId
        {
            get
            {
                return this.config.Value.UTUserId;
            }
        }

        public string UserName
        {
            get
            {
                return this.config.Value.UTUserName;
            }
        }

        public string FirstName
        {
            get
            {
                return this.config.Value.UTFirstName;
            }
        }

        public string[] Roles
        {
            get
            {
                return this.config.Value.UTUserRoles.Split(',');
            }
        }

        public string[] Privileges
        {
            get
            {
                return this.config.Value.UTPrivileges.Split(',');
            }
        }
    }
}
