using Sampler.CQRS.Core;
using Sampler.CQRS.Source.Commands;
using Sampler.CQRS.Source.Events;

namespace Sampler.CQRS.Migrations.CommandHandlers
{
    public class UpgradeDatabaseCommandHandler : ICommandHandler<UpgradeDatabaseCommand>
    {
        private readonly IDbMigrator dbMigrator;
        private readonly IMessageBus messageBus;

        public UpgradeDatabaseCommandHandler(IDbMigrator dbMigrator, IMessageBus messageBus)
        {
            this.dbMigrator = dbMigrator;
            this.messageBus = messageBus;
        }

        public CommandResult Execute(UpgradeDatabaseCommand command)
        {
            bool result = true;

            if (command.Run)
            {
                result = this.dbMigrator.Migrate();
            }

            // Publish UpgradeDatabaseCompleted
            this.messageBus.Publish(new UpgradeDatabaseCompletedEvent
            {
                Upgraded = result,
            });

            return new CommandResult(result);
        }
    }
}
