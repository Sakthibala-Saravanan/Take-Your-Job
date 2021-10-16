using AspireSystems.Service.Attributes;
using AspireSystems.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Models
{
    [EntityIdentifier(Name = "Interviewer")]
    public class Interviewer:BaseModel
    {
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role RoleDetails { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public long MobileNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string CompanyType { get; set; }
        public string CompanyAddress{ get; set; }
        public long Pincode { get; set; }
 }

}

