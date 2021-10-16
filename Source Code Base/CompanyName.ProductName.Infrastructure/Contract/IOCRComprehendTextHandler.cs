using System.Collections.Generic;

namespace AspireSystems.TakeYourJob.Infrastructure.Contract
{
    public interface IOcrComprehendTextHandler
    {
        List<Dictionary<string, string>> ComprehendText(List<string> textCollection);
        Dictionary<string, string> ComprehendEntitiesText(string text);
        void ComprehendBatchEntitiesText(List<string> text);
    }
}
