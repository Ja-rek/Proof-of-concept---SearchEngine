using FluentNHibernate.Mapping;

namespace Aveneo.SearchEngine.Infrastructure.DataModel.Mapping
{
    public class CompanyStatisticMapper : ClassMap<CompanyStatisticData>
    {
        public CompanyStatisticMapper()
        {
            Id(x => x.Id);
            Map(x => x.Headers).CustomSqlType("TEXT");
            Map(x => x.ValueToSearch).CustomSqlType("TEXT");
            Map(x => x.Status);
            Map(x => x.CompanyId);
            Map(x => x.Date);
        }
    }
}
