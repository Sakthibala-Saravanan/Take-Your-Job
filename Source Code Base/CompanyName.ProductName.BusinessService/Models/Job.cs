using AspireSystems.Service.Attributes;
using AspireSystems.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Models
{
    [EntityIdentifier(Name = "Job")]
    public class Job:BaseModel
    {
        public Guid RecruiterId { get; set; }
        [ForeignKey("RecruiterId")]
        public Interviewer UserId { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public string Skills { get; set; }
        public string Qualification { get; set; }
        public int SSLCPercentage { get; set; }
        public int HSCPercenatge { get; set; }
     }
}
