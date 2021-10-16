namespace AspireSystems.SqlRepository.Migrator
{
    using CommandLine;
    using CommandLine.Text;
    public class CommandLineOptions
    {
        [Option('x', "preview-only",
            HelpText = "Generates a preview of SQL scripts. Migrations will not be applied.",
            DefaultValue = false)]
        public bool PreviewOnly { get; set; }

        [Option('c', "connection-string-value",
            HelpText = "Connection string value for the target database. If not provided, the connection string will be used from the configuration file.",
            DefaultValue = null)]
        public string ConnectionStringValue { get; set; }

        [Option('n', "connection-string-name",
            HelpText = "Connection string name for the target database to be used in the configuration file.",
            DefaultValue = null)]
        public string ConnectionStringName { get; set; }

        // When *not* using connection string value or name, the following can be used

        [Option('s', "server",
            HelpText = "The name or network address of the instance of SQL Server to which to connect (Synonym with Data Source). The port number can be specified after the server name, e.g. server=tcp:servername,portnumber",
            DefaultValue = null)]
        public string Server { get; set; }

        [Option('d', "database",
            HelpText = "The name of the database. (Synonym with Initial Catalog)",
            DefaultValue = null)]
        public string Database { get; set; }

        [Option('u', "user-id",
            HelpText = "The SQL Server login account (when using SQL Server Authentication)",
            DefaultValue = null)]
        public string UserId { get; set; }

        [Option('p', "password",
            HelpText = "The password for the SQL Server account logging on (when using SQL Server Authentication)",
            DefaultValue = null)]
        public string Password { get; set; }

        [Option('e', "encrypt",
            HelpText = "Use SSL encryption for all data sent between the client and server if the server has a certificate installed",
            DefaultValue = false)]
        public bool Encrypt { get; set; }

        [Option('t', "trust-server-certificate",
            HelpText = "Encrypt the channel when bypassing walking the certificate chain to validate trust",
            DefaultValue = false)]
        public bool TrustServerCertificate { get; set; }

        [Option('v', "version-no",
            HelpText = "Migrate the sql to a particular version",
            DefaultValue = null)]
        public int? VersionNo { get; set; }

        [Option("dbtype",
            HelpText = "Database type (SqlServer2012)",
            DefaultValue = "SqlServer2012")]
        public string DbType { get; set; }

        [Option("tags",
            HelpText = "Setting the environment tags",
            DefaultValue = null)]
        public string Tags { get; set; }

        [Option("steps",
            HelpText = "The number of versions to rollback if the task is ‘rollback’. Default is 1",
            DefaultValue = null)]
        public int? Steps { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
