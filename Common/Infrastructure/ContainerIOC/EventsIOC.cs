using System;
using System.Collections.Generic;
using Autofac;
using Aveneo.Common.Domain.Events;

namespace Aveneo.Common.Infrastructure.ContainerIOC
{
    public class EventsIOC : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventPublisher>().AsSelf();

            builder.Register<Func<Type, IEnumerable<IHandler>>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return t =>
                {
                    var handlerType = typeof(IHandleEvent<>).MakeGenericType(t);
                    var handlersCollectionType = typeof(IEnumerable<>).MakeGenericType(handlerType);
                    return (IEnumerable<IHandler>)ctx.Resolve(handlersCollectionType);
                };
            });
        }
    }
}
