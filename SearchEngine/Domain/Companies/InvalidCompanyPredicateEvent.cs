using System.Collections.Generic;
using Aveneo.SearchEngine.Domain.Statistics;
using Aveneo.SearchEngine.Common;
using Aveneo.Common.Domain.Events;

namespace Aveneo.SearchEngine.Domain.Companies
{
    public class InvalidCompanyPredicateEvent : StatisticEvent, IEvent
    {
        public InvalidCompanyPredicateEvent(string filterPredicate, IEnumerable<HttpHeader> headers) 
            : base(filterPredicate, Status.InvalidPredicate, headers)
        {
        }
    }
}
