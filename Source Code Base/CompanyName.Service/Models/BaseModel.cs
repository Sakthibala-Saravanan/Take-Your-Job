using System;
using System.Runtime.Serialization;
using AspireSystems.Service.ModelContracts;

namespace AspireSystems.Service.Models
{
    [DataContract]
    public class BaseModel : IBaseModel
    {
        public Guid Id { get; set; }

        #region Audit Values
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        #endregion
    }
}
