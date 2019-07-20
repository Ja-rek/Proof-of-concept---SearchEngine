using AutoMapper;
using Aveneo.Common.Domain.Events;
using Aveneo.SearchEngine.Domain.Companies;
using Aveneo.SearchEngine.Domain.Statistics;
using Aveneo.SearchEngine.Infrastructure.DataModel;
using NHibernate;

namespace Aveneo.SearchEngine.Infrastructure.CompanyStores
{
    internal class CompanyStatisticEventStore<TCompanyStatisticEvent> : ICompanyStatisticEventStore<TCompanyStatisticEvent>
        where TCompanyStatisticEvent : StatisticEvent, IEvent
    {
        private readonly ISession session;

        public CompanyStatisticEventStore(ISession session)
        {
            this.session = session;
        }

        public void Store(TCompanyStatisticEvent @event)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TCompanyStatisticEvent, CompanyStatisticData>());

            var companyStatisticData = config.CreateMapper().Map<CompanyStatisticData>(@event);

            using (var transaction = session.BeginTransaction())
            {
                session.Save(companyStatisticData);
                transaction.Commit();
            }
        }
    }
}
