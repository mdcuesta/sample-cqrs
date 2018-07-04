using System.Collections.Generic;
using Sampler.CQRS.Caching.Models;

namespace Sampler.CQRS.Caching
{
    public class MemoryDataContext : IDataContext
    {
        public List<Department> DepartmentsCache;
        public List<Employee> EmployeesCache;
        public List<DepartmentEmployee> DepartmentEmployeesCache;

        public IReadOnlyCollection<Department> Departments => DepartmentsCache.AsReadOnly();

        public IReadOnlyCollection<Employee> Employees => EmployeesCache.AsReadOnly();

        public IReadOnlyCollection<DepartmentEmployee> DepartmentEmployees => DepartmentEmployeesCache.AsReadOnly();
    }
}
