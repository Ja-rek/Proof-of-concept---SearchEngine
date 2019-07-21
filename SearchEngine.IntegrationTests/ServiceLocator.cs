using Autofac;
using Aveneo.Common.Domain.Events;
using Aveneo.Common.Infrastructure.Persistence;
using Aveneo.SearchEngine.Infrastructure.DataModel;
using NHibernate;

namespace Aveneo.SearchEngine.IntegrationTest
{
    internal class ServiceLocator
    {
        public static TService Resolve<TService>()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterAssemblyModules(typeof(IEvent).Assembly);
            builder.RegisterAssemblyModules(typeof(CompanyData).Assembly);
            builder.Register(c => SessionFactory.Session(m => m.FluentMappings.AddFromAssemblyOf<CompanyData>()))
                .As<ISession>();

            return builder.Build().BeginLifetimeScope().Resolve<TService>();
        }
    }
}
