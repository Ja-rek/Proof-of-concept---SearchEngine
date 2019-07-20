using FluentNHibernate.Mapping;

namespace Aveneo.SearchEngine.Infrastructure.DataModel.Mapping
{
    class AddressMapper : ClassMap<AddressData>
    {
        public AddressMapper()
        {
            Id(x => x.Id);
            Map(x => x.City).Length(620);
            Map(x => x.Street).Length(620);
            Map(x => x.PostCode).Length(5);
            Map(x => x.SuiteOrApartament).Length(60);
        }
    }
}
