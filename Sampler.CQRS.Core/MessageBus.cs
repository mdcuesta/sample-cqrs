using System;
using System.Collections.Generic;
using System.Threading;
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
            IEnumerable<IMessageHandler<TMessage>> messageHandlers =
                this.serviceProvider.GetServices<IMessageHandler<TMessage>>();

            foreach (var messageHandler in messageHandlers)
            {
                ThreadPool.QueueUserWorkItem(x => messageHandler.Handle(message));
            }
        }
    }
}
