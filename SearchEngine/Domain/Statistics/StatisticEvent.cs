using System;

namespace Aveneo.SearchEngine.Domain.Companies
{
    internal abstract class StatisticEvent<TWantedValue>
    {
        public StatisticEvent(TWantedValue wantedValue, string headers, DateTime date)
        {
            WantedValue = wantedValue;
            Headers = headers;
            Date = date;
        }

        public TWantedValue WantedValue { get; }
        public string Headers { get; }
        public DateTime Date { get; }
    }
}
