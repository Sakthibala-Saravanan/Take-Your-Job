using AspireSystems.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AspireSystems.TakeYourJob.Infrastructure.Dtos
{
   public class LoginDto:BaseDto
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string RoleId { get; set; }
   }
}
