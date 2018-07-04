using System.Data;

namespace Sampler.CQRS.Data
{
    public interface IConnectionManager
    {
        IDbConnection Create();
    }
}
