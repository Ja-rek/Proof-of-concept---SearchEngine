using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Autofac;
using Aveneo.SearchEngine.Infrastructure.ContenerIOC;
using Aveneo.SearchEngine.Infrastructure.DataModel;
using Aveneo.Common.Infrastructure.ContainerIOC;
using Aveneo.Common.Infrastructure.Persistence;

namespace Aveneo.Bootstrap
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(Assembly.GetAssembly(typeof(EventsIOC)));
            builder.RegisterAssemblyModules(Assembly.GetAssembly(typeof(SearchEngineIOC)));

            builder.Register(c => SessionFactory.Session(m => m.FluentMappings.AddFromAssemblyOf<CompanyData>()))
                .As<ISession>()
                .InstancePerLifetimeScope();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
