using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Events
{
    public class UpgradeDatabaseCompletedEvent : IMessage
    {
        public bool Upgraded { get; set; }
    }
}
