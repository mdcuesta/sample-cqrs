using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Queries
{
    public class GetEmployeeQuery : IQuery
    {
        public int EmployeeId { get; set; }
    }
}
