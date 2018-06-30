using Sampler.CQRS.Core;
using Sampler.CQRS.Source.Commands;

namespace Sampler.CQRS.Migrations
{
    public class MigrationCommandHandler : ICommandHandler<MigrationCommand>
    {
        private readonly IDbMigrator dbMigrator;

        public MigrationCommandHandler(IDbMigrator dbMigrator)
        {
            this.dbMigrator = dbMigrator;
        }

        public CommandResult Execute(MigrationCommand command)
        {
            if (command.Run)
            {
                this.dbMigrator.Migrate();
            }
            return new CommandResult(true);
        }
    }
}
