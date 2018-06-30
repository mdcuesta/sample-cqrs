using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Sampler.CQRS.Core
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TResult Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult
        {
            var handler = this.serviceProvider.GetService<IQueryHandler<TParameter, TResult>>();
            return handler.Retrieve(query);
        }

        public async Task<TResult> DispatchAsync<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult
        {
            var handler = this.serviceProvider.GetService<IAsyncQueryHandler<TParameter, TResult>>();
            return await handler.Retrieve(query);
        }
    }
}
