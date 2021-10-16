using AspireSystems.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AspireSystems.TakeYourJob.Infrastructure.Dtos
{
    public class JobDto:BaseDto
    {
        [DataMember]
        public string RecruiterId { get; set; }
        [DataMember]
        public string Role { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public int Experience { get; set; }
        [DataMember]
        public int Salary { get; set; }
        [DataMember]
        public string Skills { get; set; }
        [DataMember]
        public string Qualification { get; set; }
        [DataMember]
        public int SSLCPercentage { get; set; }
        [DataMember]
        public int HSCPercenatge { get; set; }

    }
}
