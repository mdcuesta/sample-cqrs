using Microsoft.Extensions.DependencyInjection;
using Sampler.CQRS.Core;

namespace Sampler.CQRS.Data
{
    public class DependencyConfig : IDependencyConfig
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IConnectionManager, SqlConnectionManager>();
        }
    }
}
