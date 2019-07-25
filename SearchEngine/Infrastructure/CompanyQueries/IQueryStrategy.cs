using System;
using System.Linq.Expressions;
using Aveneo.SearchEngine.Infrastructure.DataModel;

namespace Aveneo.SearchEngine.Infrastructure.CompanyQueries
{
    public interface IQueryStrategy
    {
        bool IsCorrectNumber(long number);
        Expression<Func<CompanyData, bool>> WherePredicate(long number);
    }
}
