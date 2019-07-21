using System.Collections.Generic;
using Aveneo.SearchEngine.Domain.Statistics;
using Aveneo.SearchEngine.Common;
using Aveneo.Common.Domain.Events;

namespace Aveneo.SearchEngine.Domain.Companies
{
    public class FoundCompanyEvent : StatisticEvent, IEvent
    {
        public FoundCompanyEvent(long numberToSearch, int companyId, IEnumerable<HttpHeader> headers) 
            : base(numberToSearch.ToString(), Status.Found, headers)
        {
            CompanyId = companyId;
        }

        public int CompanyId { get; }
    }
}
