using AspireSystems.Service.Attributes;
using AspireSystems.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Models
{
    [EntityIdentifier(Name = "AppliedCandidates")]
    public class AppliedCandidate:BaseModel
    {
      public Guid JobId { get; set; }
      [ForeignKey("JobId")]
      public Job JobDetails  { get; set; }
      public Guid CandidateId { get; set; }
      [ForeignKey("CandidateId")]
      public Applicant CandidateDetails { get; set; }
      public string JobRole { get; set; }
      public string Name { get; set; }
      public string Gender { get; set; }
      public string City { get; set; }

    }
}
