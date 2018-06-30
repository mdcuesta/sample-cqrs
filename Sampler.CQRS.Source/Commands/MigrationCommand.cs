using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Commands
{
    public class MigrationCommand : ICommand
    {
        public bool Run { get; set; }
    }
}
