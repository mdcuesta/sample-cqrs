using System.Reflection;
using DbUp;
using DbUp.Engine;
using Microsoft.Extensions.Configuration;

namespace Sampler.CQRS.Migrations
{
    public class DbMigrator : IDbMigrator
    {
        private const string DB_CONNECTION = "DbConnection";

        private readonly IConfiguration configuration;
        
        public DbMigrator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool Migrate()
        {
            string connectionString = this.configuration.GetConnectionString(DB_CONNECTION);

            EnsureDatabase.For.SqlDatabase(connectionString);

            UpgradeEngine upgradeEngine =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetAssembly(GetType()))
                    .LogToConsole()
                    .Build();
            
            DatabaseUpgradeResult upgradeResult = upgradeEngine.PerformUpgrade();
            return upgradeResult.Successful;
        }
    }
}
