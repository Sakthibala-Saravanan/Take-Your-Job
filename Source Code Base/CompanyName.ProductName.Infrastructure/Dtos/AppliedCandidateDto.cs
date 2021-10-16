using AspireSystems.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AspireSystems.TakeYourJob.Infrastructure.Dtos
{
    public class AppliedCandidateDto:BaseDto
    {
        [DataMember]
        public string JobId { get; set; }
        [DataMember]
        public string CandidateId { get; set; }
        [DataMember]
        public string JobRole { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string City { get; set; }

    }
}
