using System.Data;
using Sampler.CQRS.Core;

namespace Sampler.CQRS.Data
{
    public abstract class SqlTransactionCommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly IUnitOfWork unitOfWork;

        protected IDbConnection Connection => this.unitOfWork.Connection;

        protected SqlTransactionCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public CommandResult Execute(TCommand command)
        {
            try
            {
                this.unitOfWork.Begin();
                CommandResult result = ExecuteCommand(command);
                this.unitOfWork.Commit();
                return result;
            }
            catch
            {
                this.unitOfWork.RollBack();
                throw;
            }
        }

        public abstract CommandResult ExecuteCommand(TCommand command);
    }
}
