using System.Collections.Generic;

namespace AspireSystems.TakeYourJob.Infrastructure.Contract
{
    public interface IOcrHandler
    {
        List<Dictionary<string, string>> DetectText(byte[] bytes);
    }
}
