using System.Collections.Generic;
using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Queries
{
    public class GetAllDepartmentsQueryResult : IQueryResult
    {
        public IEnumerable<GetAllDepartmentsQueryDepartment> Departments { get; set; }
    }

    public class GetAllDepartmentsQueryDepartment
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public bool IsActive { get; set; }
    }
}
