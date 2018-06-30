namespace Sampler.CQRS.Core
{
    public interface ICommandHandler<in TParameter> where TParameter : ICommand
    {
        CommandResult Execute(TParameter command);
    } 
}
