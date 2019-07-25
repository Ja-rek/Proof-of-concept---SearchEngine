using System;
using System.Linq.Expressions;
using Aveneo.SearchEngine.Infrastructure.DataModel;

namespace Aveneo.SearchEngine.Infrastructure.CompanyQueries.QueryStrategy
{
    public class NipOrKsrQueryStrategy : IQueryStrategy
    {
        public bool IsCorrectNumber(long number)
        {
            return Math.Ceiling(Math.Log10(number)) == 10;
        }

        public Expression<Func<CompanyData, bool>> WherePredicate(long number)
        {
            return x => x.Nip == number || x.Ksr == number;
        }
    }
}
