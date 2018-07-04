using Sampler.CQRS.Core;
using Sampler.CQRS.Source.Commands;

namespace Sampler.CQRS.Migrations
{
    public class Ininitalizer : IInitializer
    {
        private readonly ICommandDispatcher commandDispatcher;

        public Ininitalizer(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public void Init()
        {
            var migrationCommand = new UpgradeDatabaseCommand
            {
                Run = true,
            };

            CommandResult migrationCommandResult = this.commandDispatcher.Dispatch(migrationCommand);

            var loadCacheCommand = new LoadCacheCommand();
            CommandResult loadCacheCommandResult = this.commandDispatcher.Dispatch(loadCacheCommand);
        }
    }
}
