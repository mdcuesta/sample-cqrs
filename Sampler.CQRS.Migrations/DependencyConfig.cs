using Microsoft.Extensions.DependencyInjection;
using Sampler.CQRS.Core;

namespace Sampler.CQRS.Migrations
{
    public class DependencyConfig : IDependencyConfig
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDbMigrator, DbMigrator>();
        }
    }
}
