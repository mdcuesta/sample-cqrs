using System.Data;

namespace Sampler.CQRS.Data
{
    public interface IUnitOfWork
    {
        IDbConnection Connection { get; }

        void Begin();

        void BeginAsync();

        void Commit();

        void RollBack();
    }
}
