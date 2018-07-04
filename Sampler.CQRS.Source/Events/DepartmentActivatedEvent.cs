using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Events
{
    public class DepartmentActivatedEvent : IMessage
    {
        public int DepartmentId { get; set; }

        public string Comment { get; set; }
    }
}
