using Autofac;
using Aveneo.Common.Domain.Events;
using Common.IntegrationTest.Domain.Events.Sut;

namespace Common.IntegrationTest
{
    internal class ServiceLocator
    {
        public static TService Resolve<TService>()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterAssemblyModules(typeof(IEvent).Assembly);
            builder.RegisterType<EventHandlerMock>().AsImplementedInterfaces();

            return builder.Build().BeginLifetimeScope().Resolve<TService>();
        }
    }
}
