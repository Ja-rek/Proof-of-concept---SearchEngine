using System.Collections.Generic;
using Aveneo.SearchEngine.Common;

namespace Aveneo.SearchEngine.Domain.Statistics
{
    internal abstract class StatisticEvent
    {
        public StatisticEvent(string predicate, Status status, IEnumerable<HttpHeader> headers)
        {
            Predicate = predicate;
            Status = status;
            Headers = headers;
        }

        public string Predicate { get; }
        public Status Status { get; }
        public IEnumerable<HttpHeader> Headers { get; }
    }
}
