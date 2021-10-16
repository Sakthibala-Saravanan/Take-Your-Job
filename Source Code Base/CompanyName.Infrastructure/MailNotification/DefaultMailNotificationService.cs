using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AspireSystems.Diagnostics.Logging;
using AspireSystems.Infrastructure.MailNotification.Contracts;
using AspireSystems.Infrastructure.Models;

namespace AspireSystems.Infrastructure.Helpers
{
    /// <summary>
    /// Class for sending emails through SMTP client
    /// </summary>
    public class DefaultMailNotificationService : IDefaultMailNotificationService
    {
        private AppSettings AppSettings { get; set; }
        private SmtpClient SmtpClient { get; set; }
        private readonly IDefaultLogger defaultLogger;
        public DefaultMailNotificationService(IOptions<AppSettings> appSettings, IDefaultLogger DefaultLogger)
        {
            defaultLogger = DefaultLogger;
            AppSettings = appSettings.Value;
            SmtpClient = new SmtpClient(AppSettings.smtpClientServer)
            {
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(AppSettings.UserName, AppSettings.Password),
                Port = int.Parse(AppSettings.Port),
                //EnableSsl = true,
                EnableSsl = AppSettings.smtpSSL,
            };
        }
        public async Task SendMailAsync(EmailNotification emailNotification)
        {
            defaultLogger.LogTrace("Started to form mail");
            MailMessage mailMessage = new MailMessage();
            defaultLogger.LogTrace(emailNotification.FromAddress);
            var fromEmail = emailNotification.FromAddress;
            MailAddress fromMail = new MailAddress(fromEmail);
            mailMessage.From = fromMail;
            mailMessage.Subject = emailNotification.Subject;
            mailMessage.Body = emailNotification.Body;
            mailMessage.IsBodyHtml = true;
            if (emailNotification.attachment != null)
                mailMessage.Attachments.Add(emailNotification.attachment);
            if (emailNotification.attachments != null && emailNotification.attachments.Any())
                emailNotification.attachments.ForEach(a => { mailMessage.Attachments.Add(a); });
            if (emailNotification.CCAdresses != null)
            {
                foreach (var address in emailNotification.CCAdresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    mailMessage.CC.Add(address);
                }
            }
            foreach (var address in emailNotification.ToAddress.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                mailMessage.To.Add(address);
            }
            defaultLogger.LogTrace("mail started");
            await SmtpClient.SendMailAsync(mailMessage);
            defaultLogger.LogTrace("mail notifiaction sent");
        }
    }
}
