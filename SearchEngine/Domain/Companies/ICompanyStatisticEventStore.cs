using Aveneo.SearchEngine.Domain.Statistics;

namespace Aveneo.SearchEngine.Domain.Companies
{
    internal interface ICompanyStatisticEventStore<TCompanyStatisticEvent> 
        where TCompanyStatisticEvent : StatisticEvent
    {
        void Store(TCompanyStatisticEvent @event);
    }
}
