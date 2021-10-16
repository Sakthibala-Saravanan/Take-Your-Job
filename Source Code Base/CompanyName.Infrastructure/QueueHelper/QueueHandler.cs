using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Threading.Tasks;
using AspireSystems.Infrastructure.Models;
using AspireSystems.Infrastructure.QueueHelper.Contract;

namespace AspireSystems.Infrastructure.QueueHelper
{
    public class QueueHandler : IQueueHandler
    {
        #region Members       
        private readonly AppSettings config;
        #endregion

        #region Constructor       
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueHandler"/> class.
        /// </summary>
        /// <param name="appSettings">The application settings.</param>
        public QueueHandler(IOptions<AppSettings> appSettings)
        {
            config = appSettings.Value;
        }
        #endregion

        #region Public Methods       
        /// <summary>
        /// Sends the message to queue asynchronous.
        /// </summary>
        /// <param name="queueUrl">The queue URL.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<bool> SendMessageToQueueAsync(string queueUrl, string message)
        {
            try
            {
                var client = new AmazonSQSClient(config.awsAccessKey, config.awsSecretKey, RegionEndpoint.GetBySystemName(config.regionEndPoint));
                var uniqueMessageId = Guid.NewGuid().ToString();
                var request = new SendMessageRequest
                {
                    MessageGroupId = uniqueMessageId,
                    MessageDeduplicationId = uniqueMessageId,
                    MessageBody = message,
                    QueueUrl = queueUrl
                };
                var response = await client.SendMessageAsync(request);
                if(response.HttpStatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
