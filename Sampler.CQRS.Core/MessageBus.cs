using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Sampler.CQRS.Core
{
    public class MessageBus : IMessageBus
    {
        private readonly IServiceProvider serviceProvider;

        public MessageBus(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            IEnumerable<IMessageHandler<TMessage>> handlers =
                this.serviceProvider.GetServices<IMessageHandler<TMessage>>();
            foreach (var eventHandler in handlers)
            {
                eventHandler.Handle(message);
            }
        }
    }
}
