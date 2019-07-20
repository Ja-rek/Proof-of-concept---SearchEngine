using Aveneo.Common.Domain.Events;
using Aveneo.SearchEngine.Domain.Companies;
using Aveneo.SearchEngine.Domain.Statistics;

namespace Aveneo.SearchEngine.Application.CompanyEventHandlers
{
    internal class CompanyStatisticEventStoreHandler<TStatisticEvent> : IHandleEvent<TStatisticEvent> 
        where TStatisticEvent : StatisticEvent, IEvent
    {
        private readonly ICompanyStatisticEventStore<TStatisticEvent> eventStore;

        public CompanyStatisticEventStoreHandler(ICompanyStatisticEventStore<TStatisticEvent> eventStore)
        {
            this.eventStore = eventStore;
        }

        public void Handle(TStatisticEvent @event)
        {
            this.eventStore.Store(@event);
        }
    }
}
