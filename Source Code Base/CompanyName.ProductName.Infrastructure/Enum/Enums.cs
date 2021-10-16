namespace AspireSystems.TakeYourJob.Infrastructure.Enum
{
    
    public enum CompletionStatus
    {
        Pending = 0,
        InProgress = 1,
        Completed = 2,
        Published = 3,
        Failed = -1
    }
    public enum AuditLogType
    {
        LoginSuccess = 1,
        LogoutSuccess = 2,
    }    
}
