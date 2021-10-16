namespace AspireSystems.SqlRepository.Migrator
{
    using CommandLine;
    using AspireSystems.SqlRepository.Migrator.Helpers;
    using System;
    using System.Reflection;
    public class Program
    {
        private readonly Assembly _migrationAssembly;

        public Program(Assembly migrationAssembly)
        {
            this._migrationAssembly = migrationAssembly;
        }

        public void RunTask(string[] args)
        {
            var commandLineOptions = new CommandLineOptions();

            if (Parser.Default.ParseArguments(args, commandLineOptions) == false)
            {
                Console.WriteLine("[ERROR]: failed parsing command line options.");
                return;
            }

            var connectionString = MigratorHelper.GetConnectionString(commandLineOptions);

            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("[ERROR]: Unable to find a connection string for the target database.");
                return;
            }
            if (commandLineOptions.Steps.HasValue)
            {
                if (commandLineOptions.Steps < 1)
                {
                    Console.WriteLine("[ERROR]: failed parsing command line options.");
                    return;
                }
            }

            //var runner = new FluentRunner(connectionString, typeof(Program).Assembly, commandLineOptions.DbType, commandLineOptions.Tags);
            var runner = new FluentRunner(connectionString, this._migrationAssembly, commandLineOptions.DbType, commandLineOptions.Tags);

            try
            {
                if (commandLineOptions.PreviewOnly)
                {
                    // pass parameter "-x" to the TestApp1.SqlRepository.Migrator (defaults to false)
                    runner.Preview();
                    Console.WriteLine("[Information] Preview SQL ran successfully");
                }
                else
                {
                    // pass parameter "-v" to the TestApp1.SqlRepository.Migrator (defaults to latest/highest version)
                    if (commandLineOptions.VersionNo.HasValue)
                    {
                        runner.MigrateTo(commandLineOptions.VersionNo.Value);
                    }
                    else if (commandLineOptions.Steps.HasValue)
                    {
                        if (commandLineOptions.Steps > 0)
                        {
                            runner.Steps = commandLineOptions.Steps.Value;
                            runner.RollbackToStep();
                        }
                    }
                    else
                    {
                        runner.MigrateToLatest();
                    }

                    Console.WriteLine("[Information] Migrations applied successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[FATAL] Exception occurred: {0}", ex);
                throw; // throw exception to get non-zero exit code (which will hopefully also fail deployment step)
            }
        }
    }
}
