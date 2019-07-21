using System;
using System.Linq.Expressions;
using Aveneo.SearchEngine.Infrastructure.DataModel;

namespace Aveneo.SearchEngine.Infrastructure.CompanyQueries
{
    public interface IQueryStrategy
    {
        bool IsCorrectNumber(long predicate);
        Expression<Func<CompanyData, bool>> WhereCriteria(long predicate);
    }
}
