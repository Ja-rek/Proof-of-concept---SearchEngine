using System.Collections.Generic;
using Aveneo.SearchEngine.Domain.Statistics;
using Aveneo.SearchEngine.Common;
using Aveneo.Common.Domain.Events;

namespace Aveneo.SearchEngine.Domain.Companies
{
    public class NotFonudCompanyEvent : StatisticEvent, IEvent
    {
        public NotFonudCompanyEvent(long numberToSearch, IEnumerable<HttpHeader> headers) 
            : base(numberToSearch.ToString(), Status.NotFound, headers)
        {
        }
    }
}
