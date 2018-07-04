using System.Collections.Generic;
using Sampler.CQRS.Caching.Models;

namespace Sampler.CQRS.Caching
{
    public interface IDataContext
    {
        IReadOnlyCollection<Department> Departments { get; }

        IReadOnlyCollection<Employee> Employees { get; }

        IReadOnlyCollection<DepartmentEmployee> DepartmentEmployees { get; }
    }
}
