using System.Reflection;
using Core.Intefraces;
using DbUp;
using DbUp.Postgresql;
using Microsoft.Extensions.Logging;

namespace Migrations;

public class Migrator(ISettings settings, ILogger logger)
{
    private string ConnectionString => settings.GetValue("postgres:connectionString");
    private string DatabaseName => settings.GetValue("postgres:databaseName");
    private string SchemaName => settings.GetValue("postgres:schemaName");

    public void Migrate()
    {
        var builder = DeployChanges.To
            .PostgresqlDatabase(ConnectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .WithTransaction()
            .WithVariablesDisabled()
            .LogToConsole();
        
        builder.Configure(c =>
            c.Journal = new PostgresqlTableJournal(() =>
                    c.ConnectionManager,
                () => c.Log, SchemaName,
                "migrations_history"));
        
        var upgradeEngine = builder.Build();

        if (!upgradeEngine.IsUpgradeRequired())
        {
            return;
        }

        var result = upgradeEngine.PerformUpgrade();

        if (!result.Successful)
        {
            logger.LogError(result.Error.ToString());
        }
    }
}