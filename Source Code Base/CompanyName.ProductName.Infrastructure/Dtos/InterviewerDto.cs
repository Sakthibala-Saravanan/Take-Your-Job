using AspireSystems.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AspireSystems.TakeYourJob.Infrastructure.Dtos
{
    public class InterviewerDto:BaseDto
    {
        [DataMember]
        public string RoleId { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public long MobileNumber { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string ConfirmPassword { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CompanyType { get; set; }
        [DataMember]
        public string CompanyAddress { get; set; }
        [DataMember]
        public long Pincode { get; set; }
    }
}
