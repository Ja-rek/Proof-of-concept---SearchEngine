using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using System;

namespace Aveneo.Common.Infrastructure.Persistence
{
    public static class SessionFactory
    {
        public static ISession Session(Action<MappingConfiguration> mapping, bool createDb = false)
        {
            var mySql = "server=localhost;User Id=root; password=Password; database=Aveneo;";

            Action<NHibernate.Cfg.Configuration> shemaConfig = (cfg) => 
            { 
                if (createDb) new SchemaExport(cfg).Create(true, createDb); 
                new SchemaUpdate(cfg).Execute(true, true); 
            };

            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(mySql).ShowSql())
                .Mappings(mapping)
                .ExposeConfiguration(shemaConfig)
                .BuildSessionFactory()
                .OpenSession();
        }
    }
}
