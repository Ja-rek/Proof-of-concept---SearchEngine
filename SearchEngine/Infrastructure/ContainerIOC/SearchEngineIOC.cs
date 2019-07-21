using System.Linq;
using System.Reflection;
using Autofac;
using Aveneo.Common.Domain.Events;
using Aveneo.SearchEngine.Application.Companies;
using Aveneo.SearchEngine.Application.CompanyEventHandlers;
using Aveneo.SearchEngine.Infrastructure.CompanyQueries;
using Aveneo.SearchEngine.Infrastructure.CompanyStores;

namespace Aveneo.SearchEngine.Infrastructure.ContenerIOC
{
    public class SearchEngineIOC : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyQueryService>().AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(CompanyStatisticEventStore<>)).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(CompanyStatisticEventStoreHandler<>)).As(typeof(IHandleEvent<>));

            var type = typeof(IQueryStrategy);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(x => type.IsAssignableFrom(x) && x != type)
                .AsImplementedInterfaces();

            builder.RegisterType<CompanySearchService>().AsSelf();
        }
    }
}
