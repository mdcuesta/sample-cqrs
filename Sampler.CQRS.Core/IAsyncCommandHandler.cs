using System.Threading.Tasks;

namespace Sampler.CQRS.Core
{
    public interface IAsyncCommandHandler<in TParameter> where TParameter : ICommand
    {
        Task<CommandResult> Execute(TParameter command);
    }
}
