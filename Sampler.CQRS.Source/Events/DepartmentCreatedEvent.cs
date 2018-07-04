using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Events
{
    public class DepartmentCreatedEvent : IMessage
    {
        public int DepartmentId { get; set; }
    }
}
