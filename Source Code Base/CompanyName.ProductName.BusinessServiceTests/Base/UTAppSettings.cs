using System;
using System.Collections.Generic;
using System.Text;
using AspireSystems.Infrastructure.Models;

namespace AspireSystems.TakeYourJob.BusinessServiceTests.Base
{
    public class UTAppSettings : AppSettings
    {
        public string UTUserId { get; set; }
        public string UTUserName { get; set; }
        public string UTFirstName { get; set; }
        public string UTUserRoles { get; set; }
        public string UTPrivileges { get; set; }
    }
}
