using System.Collections.Generic;
using Aveneo.SearchEngine.Domain.Statistics;
using Aveneo.SearchEngine.Common;
using Aveneo.Common.Domain.Events;

namespace Aveneo.SearchEngine.Domain.Companies
{
    internal class NotFonudCompanyEvent : StatisticEvent, IEvent
    {
        public NotFonudCompanyEvent(long predicate, IEnumerable<HttpHeader> headers) 
            : base(predicate.ToString(), Status.NotFound, headers)
        {
        }
    }
}
