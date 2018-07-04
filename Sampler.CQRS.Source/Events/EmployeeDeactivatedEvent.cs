using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Events
{
    public class EmployeeDeactivatedEvent : IMessage
    {
        public int EmployeeId { get; set; }

        public string Comment { get; set; }
    }
}
