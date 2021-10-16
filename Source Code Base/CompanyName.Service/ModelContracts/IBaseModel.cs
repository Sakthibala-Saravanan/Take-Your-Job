using System;

namespace AspireSystems.Service.ModelContracts
{
    public interface IBaseModel : IAuditModel
    {
        Guid Id { get; set; }
    }
}
