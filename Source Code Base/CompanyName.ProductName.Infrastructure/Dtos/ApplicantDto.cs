using AspireSystems.Api.Dtos;
using System.Runtime.Serialization;

namespace AspireSystems.TakeYourJob.Infrastructure.Dtos
{
    public class ApplicantDto : BaseDto
    {
        /// <summary>
        ///Candidate Personal details
        /// </summary>
        [DataMember]
        public string RoleId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public long MobileNumber { get; set; }
        [DataMember]
        public string DateOfBirth { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string ConfirmPassword { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Question { get; set; }
        [DataMember]
        public string Answer { get; set; }
        /// <summary>
        ///Candidate School details
        /// </summary>
        [DataMember]
        public string HSCBoard { get; set; }
        [DataMember]
        public string HSCSpecialization { get; set; }
        [DataMember]
        public int HSCPassingYear { get; set; }
        [DataMember]
        public string HSCMedium { get; set; }
        [DataMember]
        public int HSCPercentage { get; set; }
        [DataMember]
        public string SSLCBoard { get; set; }
        [DataMember]
        public int SSLCPassingYear { get; set; }
        [DataMember]
        public string SSLCMedium { get; set; }
        [DataMember]
        public int SSLCPercentage { get; set; }
        ///  <summary>
        ///Candidate College details
        /// </summary>
        [DataMember]
        public string Qualification { get; set; }
        [DataMember]
        public string Course { get; set; }
        [DataMember]
        public string Specialization { get; set; }
        [DataMember]
        public string CollegeName { get; set; }
        [DataMember]
        public string CollegeType { get; set; }
        [DataMember]
        public int PassingYear { get; set; }
        /// <summary>
        ///Candidate Work details
        /// </summary>
        [DataMember]
        public string ProfessionalBackground { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string JobType { get; set; }
        [DataMember]
        public string EmploymentType { get; set; }
        [DataMember]
        public string Skills { get; set; }
        [DataMember]
        public int Experience { get; set; }
    }
}
