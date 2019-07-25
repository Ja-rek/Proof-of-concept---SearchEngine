using System;
using System.Linq.Expressions;
using Aveneo.SearchEngine.Infrastructure.DataModel;

namespace Aveneo.SearchEngine.Infrastructure.CompanyQueries.QueryStrategy
{
    public class RegonQueryStrategy : IQueryStrategy
    {

        public bool IsCorrectNumber(long number)
        {
            return Math.Ceiling(Math.Log10(number)) == 9;
        }

        public Expression<Func<CompanyData, bool>> WherePredicate(long number)
        {
            return x => x.Regon == number;
        }
    }
}
