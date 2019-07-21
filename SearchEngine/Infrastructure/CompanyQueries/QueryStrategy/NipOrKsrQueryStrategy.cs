using System;
using System.Linq.Expressions;
using Aveneo.SearchEngine.Infrastructure.DataModel;

namespace Aveneo.SearchEngine.Infrastructure.CompanyQueries.QueryStrategy
{
    public class NipOrKsrQueryStrategy : IQueryStrategy
    {
        public bool IsCorrectNumber(long predicate)
        {
            return Math.Ceiling(Math.Log10(predicate)) == 10;
        }

        public Expression<Func<CompanyData, bool>> WhereCriteria(long predicate)
        {
            return x => x.Nip == predicate || x.Ksr == predicate;
        }
    }
}
