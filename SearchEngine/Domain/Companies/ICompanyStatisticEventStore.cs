using Aveneo.Common.Domain.Events;
using Aveneo.SearchEngine.Domain.Statistics;

namespace Aveneo.SearchEngine.Domain.Companies
{
    public interface ICompanyStatisticEventStore<TCompanyStatisticEvent> 
        where TCompanyStatisticEvent : StatisticEvent, IEvent
    {
        void Store(TCompanyStatisticEvent @event);
    }
}
