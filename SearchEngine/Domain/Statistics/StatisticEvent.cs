using System.Collections.Generic;
using Aveneo.SearchEngine.Common;

namespace Aveneo.SearchEngine.Domain.Statistics
{
    public abstract class StatisticEvent
    {
        public StatisticEvent(string valueToSearch, Status status, IEnumerable<HttpHeader> headers)
        {
            ValueToSearch = valueToSearch;
            Status = status;
            Headers = headers;
        }

        public string ValueToSearch { get; }
        public Status Status { get; }
        public IEnumerable<HttpHeader> Headers { get; }
    }
}
