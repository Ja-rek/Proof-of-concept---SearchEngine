using FluentNHibernate.Mapping;

namespace Aveneo.SearchEngine.Infrastructure.DataModel.Mapping
{
    class CompanyMapper : ClassMap<CompanyData>
    {
        public CompanyMapper()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(620);
            Map(x => x.Ksr).Length(10).Index("KSR");
            Map(x => x.Nip).Length(10).Index("NIP");
            Map(x => x.Regon).Length(9).Index("REGON");
            References(x => x.Address);
        }
    }
}
