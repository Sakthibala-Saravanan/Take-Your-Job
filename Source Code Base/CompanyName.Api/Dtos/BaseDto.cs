using System;
using System.Runtime.Serialization;
using AspireSystems.Api.DtoContracts;

namespace AspireSystems.Api.Dtos
{
    [DataContract]
    public class BaseDto : IBaseDto
    {
        [DataMember]
        public string Id { get; set; }

        #region Audit Values
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public string CreatedByUserId { get; set; }
        [DataMember]
        public DateTime? UpdatedAt { get; set; }
        [DataMember]
        public string UpdatedByUserId { get; set; }
        #endregion
    }
}
