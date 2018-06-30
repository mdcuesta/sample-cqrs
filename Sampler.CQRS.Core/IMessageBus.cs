namespace Sampler.CQRS.Core
{
    public interface IMessageBus
    {
        void Publish<TMessage>(TMessage message) where TMessage : IMessage;
    }
}
