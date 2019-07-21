using System.Linq;
using System.Reflection;
using Autofac;
using Aveneo.SearchEngine.Application.Companies;
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

            var type = typeof(IQueryStrategy);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(x => type.IsAssignableFrom(x) && x != type)
                .AsImplementedInterfaces();

            builder.RegisterType<CompanySearchService>().AsSelf();
        }
    }
}
