using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;
using AspireSystems.SqlRepository.Migrator;

namespace AspireSystems.Serve.SqlRepository.Migrator
{
    internal class Program
    {
        // ------------------------------------
        // Sample usages when running this console application from the command-line:
        // ------------------------------------
        // (1) To run migration against the DB specified in the configuration file ( * for local development)
        // TestApp1.SqlRepository.Migrator.exe
        // (2) To generate preview SQL scripts for the DB specified in the configuration file ( * for local development)
        // TestApp1.SqlRepository.Migrator.exe -x
        // (3) To run migration against the DB using a connection string specified in the command line argument
        // TestApp1.SqlRepository.Migrator.exe -c "connectionStringValueHere"
        // (4) To generate preview SQL scripts for the DB using a connection string specified in the command line argument
        // TestApp1.SqlRepository.Migrator.exe -x -c "connectionStringValueHere"
        // (5) To run migration against the DB specified in the config file with the specified connection string name  ( * for azure deployments) 
        // TestApp1.SqlRepository.Migrator.exe -n "connectionStringNameHere"
        // (6) To generate preview SQL scripts for the DB specified in the config file with the specified connection string name ( * for azure deployments) 
        // TestApp1.SqlRepository.Migrator.exe -x -n "connectionStringNameHere"
        // (7) To run migration using individual parameters, for example:
        // TestApp1.SqlRepository.Migrator.exe -s tcp:myservername.database.windows.net,1433 -d mydatabasename -u myusername@myservername -p myPassword -e true
        // (8) Command line help (using the CommandLineParser's generated help from the CommandLineOptions values)
        // TestApp1.SqlRepository.Migrator.exe --help
        // ------------------------------------
        private static void Main(string[] args)
        {
            AspireSystems.SqlRepository.Migrator.Program prg = new AspireSystems.SqlRepository.Migrator.Program(typeof(Program).Assembly);
            prg.RunTask(args);
        }
    }
}
