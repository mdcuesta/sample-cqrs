using System.Linq;
using Sampler.CQRS.Core;
using Sampler.CQRS.Source.Queries;

namespace Sampler.CQRS.Caching
{
    public class GetAllDepartmentsQueryHandler : IQueryHandler<GetAllDepartmentsQuery, GetAllDepartmentsQueryResult>
    {
        private readonly IDataContext dataContext;

        public GetAllDepartmentsQueryHandler(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public GetAllDepartmentsQueryResult Retrieve(GetAllDepartmentsQuery query)
        {
            var result = new GetAllDepartmentsQueryResult();

            result.Departments = this.dataContext.Departments.Select(d => new GetAllDepartmentsQueryDepartment
            {
                DepartmentId = d.Id,
                DepartmentName = d.Name,
                IsActive = d.IsActive,
            }).ToList();

            return result;
        }
    }
}
