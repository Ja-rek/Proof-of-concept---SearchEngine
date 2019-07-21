using Autofac;
using LightBDD.Core.Configuration;
using LightBDD.NUnit3;
using NUnit.Framework;
using LightBDD.Autofac;
using Aveneo.SearchEngine.FunctionalTests;
using Aveneo.SearchEngine.Infrastructure.DataModel;
using Aveneo.Common.Infrastructure.Persistence;
using NHibernate;
using RestSharp;

[assembly:Parallelizable(ParallelScope.Self)]
[assembly: ConfiguredLightBddScope]
namespace Aveneo.SearchEngine.FunctionalTests
{
    internal class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
    {
        protected override void OnConfigure(LightBddConfiguration configuration)
        {
            configuration.DependencyContainerConfiguration().UseAutofac(ConfigureContainer());
        }

        private IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof(CompanyData).Assembly);

            builder.Register(c => new RestClient("http://localhost:5000/api")).AsSelf();
            builder.Register(c => SessionFactory.Session(m => m.FluentMappings.AddFromAssemblyOf<CompanyData>()))
                .As<ISession>()
                .InstancePerDependency();

            builder.RegisterType<CompanyContext>().AsSelf();

            return builder.Build();
        }
    }
}
