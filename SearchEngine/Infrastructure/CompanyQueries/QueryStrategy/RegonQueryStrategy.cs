using System;
using System.Linq.Expressions;
using Aveneo.SearchEngine.Infrastructure.DataModel;

namespace Aveneo.SearchEngine.Infrastructure.CompanyQueries.QueryStrategy
{
    public class RegonQueryStrategy : IQueryStrategy
    {

        public bool IsCorrectNumber(long predicate)
        {
            return Math.Ceiling(Math.Log10(predicate)) == 9;
        }

        public Expression<Func<CompanyData, bool>> WhereCriteria(long predicate)
        {
            return x => x.Regon == predicate;
        }
    }
}
