using System.Collections.Generic;
using System.Net.Mail;

namespace AspireSystems.Infrastructure.Models
{
    /// <summary>
    /// Represents the email notification details
    /// </summary>
    public class EmailNotification
    {
        /// <summary>
        /// Gets or sets the from address
        /// </summary>
        public string FromAddress { get; set; }
        /// <summary>
        /// Gets or sets the to address
        /// </summary>
        public string ToAddress { get; set; }
        /// <summary>
        /// Gets or sets whether the mail is broadcast
        /// </summary>
        public bool IsBroadcastMail { get; set; }
        /// <summary>
        /// Gets or sets multiple to adresses
        /// </summary>
        public string ToAdresses { get; set; }
        /// <summary>
        /// Gets or sets multiple cc adresses
        /// </summary>
        public string CCAdresses { get; set; }
        /// <summary>
        /// Gets or sets multiple bcc adresses
        /// </summary>
        public string BCCAdresses { get; set; }
        /// <summary>
        /// Gets or sets the email subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets the email content
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Gets or sets the values that are placed in mail content
        /// </summary>
        public Dictionary<string,string> MailPlaceholders { get; set; }

        public Attachment attachment { get; set; }
        public List<Attachment> attachments { get; set; }

    }
}
