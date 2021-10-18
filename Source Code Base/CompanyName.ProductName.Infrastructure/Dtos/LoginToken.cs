using System;
using System.Collections.Generic;
using System.Text;

namespace AspireSystems.TakeYourJob.Infrastructure.Dtos
{
    public class LoginToken
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
