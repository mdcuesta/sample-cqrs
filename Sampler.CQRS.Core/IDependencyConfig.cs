using Microsoft.Extensions.DependencyInjection;

namespace Sampler.CQRS.Core
{
    public interface IDependencyConfig
    {
        void Configure(IServiceCollection serviceCollection);
    }
}
