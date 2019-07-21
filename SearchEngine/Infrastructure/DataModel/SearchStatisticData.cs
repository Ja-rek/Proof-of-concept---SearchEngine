using System;
using Aveneo.SearchEngine.Common;

namespace Aveneo.SearchEngine.Infrastructure.DataModel
{
    public abstract class SearchStatisticData
    {
        public virtual int Id { get; set; }
        public virtual string Predicate { get; set; }
        public virtual Status Status { get; set; }
        public virtual string Headers { get; set; }
        public virtual DateTime Date { get; set; } = DateTime.Now;
    }
}
