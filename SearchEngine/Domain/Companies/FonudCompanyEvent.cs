using System.Collections.Generic;
using Aveneo.SearchEngine.Domain.Statistics;
using Aveneo.SearchEngine.Common;
using Aveneo.Common.Domain.Events;

namespace Aveneo.SearchEngine.Domain.Companies
{
    internal class FoundCompanyEvent : StatisticEvent, IEvent
    {
        public FoundCompanyEvent(long predicate, int companyId, IEnumerable<HttpHeader> headers) 
            : base(predicate.ToString(), Status.Found, headers)
        {
            CompanyId = companyId;
        }

        public int CompanyId { get; }
    }
}
