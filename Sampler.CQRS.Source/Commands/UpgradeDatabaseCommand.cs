using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Commands
{
    public class UpgradeDatabaseCommand : ICommand
    {
        public bool Run { get; set; }
    }
}
