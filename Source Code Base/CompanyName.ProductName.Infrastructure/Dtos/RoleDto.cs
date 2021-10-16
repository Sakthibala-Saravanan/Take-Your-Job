using AspireSystems.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AspireSystems.TakeYourJob.Infrastructure.Dtos
{
    public class RoleDto:BaseDto
    {
        [DataMember]
        public string RoleName { get; set; }
    }
}
