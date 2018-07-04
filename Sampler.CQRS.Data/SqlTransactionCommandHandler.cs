using System.Data;
using System.Transactions;
using Sampler.CQRS.Core;

namespace Sampler.CQRS.Data
{
    public abstract class SqlTransactionCommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly IConnectionManager connectionManager;

        protected virtual IDbConnection Connection { get; private set; }

        protected SqlTransactionCommandHandler(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public CommandResult Execute(TCommand command)
        {
            TransactionScope transactionScope = null;
            try
            {
                transactionScope = new TransactionScope();
                Connection = this.connectionManager.Create();
                CommandResult result = ExecuteCommand(command);
                transactionScope.Complete();
                return result;
            }
            finally
            {
                if (transactionScope != null)
                {
                    transactionScope.Dispose();
                }
            }
        }

        protected abstract CommandResult ExecuteCommand(TCommand command);
    }
}
