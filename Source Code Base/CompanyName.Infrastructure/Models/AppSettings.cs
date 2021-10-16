namespace AspireSystems.Infrastructure.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string WhitelistUrls { get; set; }
        public string AuthIssuer { get; set; }
        public string awsAccessKey { get; set; }
        public string awsSecretKey { get; set; }
        public string regionEndPoint { get; set; }
        public string userPoolId { get; set; }
        public string clientId { get; set; }
        public string serviceURL { get; set; }
        public string AppURL { get; set; }
        public string CommandTimeout { get; set; }
        public string Log4NetConfig { get; set; }
        public string Environment { get; set; }

        #region Blob settings
        public string bucketName { get; set; }
        #endregion

        #region Authentication
        public string PublicKeyModulus { get; set; }
        public string PublicKeyExponent { get; set; }
        #endregion

        #region SMTP
        public string smtpClientServer { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public bool smtpSSL { get; set; }
        public string FromAddress { get; set; }
        #endregion
    }
}
