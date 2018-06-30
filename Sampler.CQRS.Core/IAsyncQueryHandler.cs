using System.Threading.Tasks;

namespace Sampler.CQRS.Core
{
    public interface IAsyncQueryHandler<in TParameter, TResult>
        where TResult : IQueryResult
        where TParameter : IQuery
    {
        Task<TResult> Retrieve(TParameter query);
    }
}
