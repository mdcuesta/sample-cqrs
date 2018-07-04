using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Events
{
    public class EmployeeActivatedEvent : IMessage
    {
        public int EmployeeId { get; set; }

        public string Comments { get; set; }
    }
}
