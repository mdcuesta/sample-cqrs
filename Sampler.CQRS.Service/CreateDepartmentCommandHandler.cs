using System.Linq;
using Dapper;
using Sampler.CQRS.Core;
using Sampler.CQRS.Data;
using Sampler.CQRS.Source.Commands;
using Sampler.CQRS.Source.Events;

namespace Sampler.CQRS.Service
{
    public class CreateDepartmentCommandHandler : SqlTransactionCommandHandler<CreateDepartmentCommand>
    {
        private readonly IMessageBus messageBus;
        private readonly IConnectionManager connectionManager;

        public CreateDepartmentCommandHandler(IConnectionManager connectionManager, IMessageBus messageBus)
            : base(connectionManager)
        {
            this.connectionManager = connectionManager;
            this.messageBus = messageBus;
        }

        protected override CommandResult ExecuteCommand(CreateDepartmentCommand command)
        {
            const string sql = "INSERT INTO Departments (Name) Values (@Name);" +
                         "SELECT CAST(SCOPE_IDENTITY() as int)";

            int id = Connection.Query<int>(sql, new { command.Name }).Single();

            if (id > 0)
            {
                this.messageBus.Publish(new DepartmentCreatedEvent
                {
                    DepartmentId = id,
                });
            }

            return new CommandResult(id > 0);
        }
    }
}
