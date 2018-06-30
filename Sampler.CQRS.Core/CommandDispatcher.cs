using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Sampler.CQRS.Core
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public CommandResult Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
            var handler = this.serviceProvider.GetService<ICommandHandler<TParameter>>();
            return handler.Execute(command);
        }

        public async Task<CommandResult> DispatchAsync<TParameter>(TParameter command) where TParameter : ICommand
        {
            var handler = this.serviceProvider.GetService<IAsyncCommandHandler<TParameter>>();
            return await handler.Execute(command);
        }
    }
}
