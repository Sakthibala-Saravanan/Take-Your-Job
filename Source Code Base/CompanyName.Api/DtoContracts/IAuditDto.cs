using System;

namespace AspireSystems.Api.DtoContracts
{
    public interface IAuditDto
    {
        bool Status { get; set; }
        DateTime CreatedAt { get; set; }
        string CreatedByUserId { get; set; }
        DateTime? UpdatedAt { get; set; }
        string UpdatedByUserId { get; set; }
    }
}
