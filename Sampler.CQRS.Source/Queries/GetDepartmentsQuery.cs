using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Queries
{
    public class GetDepartmentsQuery : IQuery
    {
        public bool IsActive { get; set; }
    }
}
