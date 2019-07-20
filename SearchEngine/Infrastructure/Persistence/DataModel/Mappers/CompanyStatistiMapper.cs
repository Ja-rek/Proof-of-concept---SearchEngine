using FluentNHibernate.Mapping;

namespace Aveneo.SearchEngine.Infrastructure.DataModel.Mapping
{
    class CompanyStatisticMapper : ClassMap<CompanyStatisticData>
    {
        public CompanyStatisticMapper()
        {
            Id(x => x.Id);
            Map(x => x.Headers);
            Map(x => x.Predicate);
            Map(x => x.Status);
            Map(x => x.CompanyId);
            Map(x => x.Date);
        }
    }
}
