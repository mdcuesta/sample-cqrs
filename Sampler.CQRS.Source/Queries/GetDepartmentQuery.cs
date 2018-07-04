using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Queries
{
    public class GetDepartmentQuery : IQuery
    {
        public int DepartmentId { get; set; }
    }
}
