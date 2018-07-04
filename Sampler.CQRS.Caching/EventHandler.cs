using System.Data;
using Dapper;
using Sampler.CQRS.Caching.Models;
using Sampler.CQRS.Core;
using Sampler.CQRS.Data;
using Sampler.CQRS.Source.Events;

namespace Sampler.CQRS.Caching
{
    public class EventHandler : IMessageHandler<DepartmentCreatedEvent>
    {
        private readonly IDataContext dataContext;
        private readonly IConnectionManager connectionManager;
        private readonly MemoryDataContext DataContext;

        public EventHandler(IDataContext dataContext, IConnectionManager connectionManager)
        {
            this.dataContext = dataContext;
            this.connectionManager = connectionManager;

            if (this.dataContext is MemoryDataContext)
            {
                DataContext = this.dataContext as MemoryDataContext;
            }
        }

        public void Handle(DepartmentCreatedEvent message)
        {
            const string sql = "SELECT Id, Name, Comment, IsActive FROM Departments WHERE Id = (@Id)";

            using (IDbConnection dbConnection = this.connectionManager.Create())
            {
                Department department = dbConnection.QuerySingle<Department>(sql, new { Id = message.DepartmentId });
                DataContext.DepartmentsCache.Add(department);
            }
        }
    }
}
