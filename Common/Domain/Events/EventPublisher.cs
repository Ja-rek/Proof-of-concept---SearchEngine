using System;
using System.Collections.Generic;
using System.Linq;

namespace Aveneo.Common.Domain.Events
{
    public class EventPublisher
    {
        private readonly Func<Type, IEnumerable<IHandler>> handlerAggregator;

        public EventPublisher(Func<Type, IEnumerable<IHandler>> handlerAggregator)
        {
            this.handlerAggregator = handlerAggregator;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handlers = this.handlerAggregator(typeof(TEvent))
                .Cast<IHandleEvent<TEvent>>();
     
            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}
