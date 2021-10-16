using System.Threading.Tasks;
using AspireSystems.Infrastructure.Models;

namespace AspireSystems.Infrastructure.MailNotification.Contracts
{
    /// <summary>
    /// Interface to expose the default mail notification service methods
    /// </summary>
    public interface IDefaultMailNotificationService
    {
        /// <summary>
        /// Method used to send mail asynchronously
        /// </summary>
        /// <returns></returns>
        Task SendMailAsync(EmailNotification emailNotification);
    }
}
