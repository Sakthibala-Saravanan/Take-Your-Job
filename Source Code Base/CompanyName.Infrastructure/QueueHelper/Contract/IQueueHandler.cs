using System.Threading.Tasks;

namespace AspireSystems.Infrastructure.QueueHelper.Contract
{
    /// <summary>
    /// Represents the contract for QueueHandler
    /// </summary>
    public interface IQueueHandler
    {
        /// <summary>
        /// Sends the message to queue asynchronous.
        /// </summary>
        /// <param name="queueUrl">The queue URL.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        Task<bool> SendMessageToQueueAsync(string queueUrl, string message);
    }
}
