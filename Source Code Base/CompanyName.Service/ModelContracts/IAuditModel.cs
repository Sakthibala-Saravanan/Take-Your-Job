using System;

namespace AspireSystems.Service.ModelContracts
{
    public interface IAuditModel
    {
        bool Status { get; set; }
        DateTime CreatedAt { get; set; }
        Guid CreatedByUserId { get; set; }
        DateTime? UpdatedAt { get; set; }
        Guid? UpdatedByUserId { get; set; }
    }
}
