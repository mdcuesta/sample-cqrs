using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Queries
{
    public class GetEmployeesQuery : IQuery
    {
        public bool IsActive { get; set; }
    }
}
