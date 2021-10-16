namespace AspireSystems.SqlRepository.Migrator
{
    using FluentMigrator.Runner.Announcers;
    using FluentMigrator.Runner.Initialization;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    public class FluentRunner
    {
        private readonly string _connectionString;
        private readonly string _database;
        private readonly Assembly _migrationAssembly;
        private string _task;
        private IList<string> _tags;
        private long _version;
        private bool _previewOnly;
        private int _steps;

        public FluentRunner(string connectionString, Assembly migrationAssembly, string database, string tags)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
            _database = database;
            _previewOnly = false;
            if (!String.IsNullOrEmpty(tags))
                _tags = tags.Split(',');
        }

        public int Steps
        {
            get { return _steps; }
            set { _steps = value; }
        }

        public void MigrateTo(long versionTo)
        {
            _version = versionTo;
            _task = _version == 0 ? "rollback:all" : "rollback:toversion";
            Execute();
        }

        public void MigrateToLatest()
        {
            _task = "migrate:up";
            Execute();
        }

        public void RollbackToStep()
        {
            _task = "rollback";
            Execute();
        }

        public void Preview()
        {
            _previewOnly = true;
            MigrateToLatest();
        }

        private void Execute()
        {
            var runnerContext = new RunnerContext(GetAnnouncer())
            {
                Database = _database,
                Task = _task,
                Connection = _connectionString,
                PreviewOnly = _previewOnly,
                Targets = new[] { _migrationAssembly.CodeBase.Replace("file:///", string.Empty) },
                Version = _version,
                Tags = _tags
            };

            if (_steps > 0)
                runnerContext.Steps = _steps;

            Trace.TraceInformation("#\n# Executing migration task {0}...\n#\n", _task);
            var localTask = new TaskExecutor(runnerContext);
            localTask.Execute();
            Trace.TraceInformation("\n#\n# Task {0} complete!\n#", _task);
        }

        private Announcer GetAnnouncer()
        {
            return new TextWriterAnnouncer(Console.Out) { ShowElapsedTime = true, ShowSql = true };
        }
    }
}
