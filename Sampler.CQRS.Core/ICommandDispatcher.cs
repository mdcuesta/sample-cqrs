using System.Threading.Tasks;

namespace Sampler.CQRS.Core
{
    public interface ICommandDispatcher
    {
        CommandResult Dispatch<TParameter>(TParameter command) where TParameter : ICommand;

        Task<CommandResult> DispatchAsync<TParameter>(TParameter command) where TParameter : ICommand;
    } 
}
