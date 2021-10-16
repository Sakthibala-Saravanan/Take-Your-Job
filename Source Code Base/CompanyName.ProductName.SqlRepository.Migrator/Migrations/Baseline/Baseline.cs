using FluentMigrator;

namespace AspireSystems.Serve.SqlRepository.Migrator.Migrations.Baseline
{
    //YYMMDDVNRN
    [Migration(2012230101, "Base line DB script")]
    [Tags("DEV", "QA", "UAT", "DEMO", "PROD", "PERF")]
    public class BaseMigration : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("BaselineScript_Up.sql");
        }

        public override void Down()
        {
            Execute.EmbeddedScript("BaselineScript_Down.sql");
        }
    }
}

