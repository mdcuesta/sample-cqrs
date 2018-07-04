using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Events
{
    public class DepartmentDeactivatedEvent : IMessage
    {
        public int DepartmentId { get; set; }

        public string Comment { get; set; }
    }
}
