using Microsoft.Extensions.DependencyInjection;
using Sampler.CQRS.Core;

namespace Sampler.CQRS.Caching
{
    public class DependencyConfig : IDependencyConfig
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDataContext, MemoryDataContext>();
        }
    }
}
