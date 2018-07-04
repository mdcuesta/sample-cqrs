using System.Collections.Generic;
using Dapper;
using Sampler.CQRS.Caching.Models;
using Sampler.CQRS.Core;
using Sampler.CQRS.Data;
using Sampler.CQRS.Source.Commands;

namespace Sampler.CQRS.Caching
{
    public class LoadCacheCommandHandler : SqlTransactionCommandHandler<LoadCacheCommand>
    {
        private readonly IDataContext dataContext;

        public LoadCacheCommandHandler(IConnectionManager connectionManager, IDataContext dataContext)
            : base(connectionManager)
        {
            this.dataContext = dataContext;
        }
        
        protected override CommandResult ExecuteCommand(LoadCacheCommand command)
        {
            const string departmentsQuery = "SELECT Id, Name, Comment, IsActive FROM Departments";
            IEnumerable<Department> departments = Connection.Query<Department>(departmentsQuery);


            const string employeesQuery = "SELECT Id, Code, FirstName, LastName, Sex, Birthday, Position, Comment, IsActive FROM Employees";
            IEnumerable<Employee> employees = Connection.Query<Employee>(employeesQuery);

            const string departmentEmployeesQuery = "SELECT Id, DepartmentId, EmployeeId FROM DepartmentEmployees";
            IEnumerable<DepartmentEmployee> departmentsEmployee = Connection.Query<DepartmentEmployee>(departmentEmployeesQuery);

            if (this.dataContext is MemoryDataContext)
            {
                var memoryDataContext = this.dataContext as MemoryDataContext;

                memoryDataContext.DepartmentsCache = departments.AsList();
                memoryDataContext.EmployeesCache = employees.AsList();
                memoryDataContext.DepartmentEmployeesCache = departmentsEmployee.AsList();
            }
            return new CommandResult(true);
        }
    }
}
