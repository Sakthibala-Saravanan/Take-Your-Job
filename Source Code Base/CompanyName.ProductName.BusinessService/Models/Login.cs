using AspireSystems.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Models
{
    public class Login:BaseModel
    {
        public string Email { get; set; }
        public string Password{ get; set; }
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role RoleDetails { get; set; }
     
    }
}
