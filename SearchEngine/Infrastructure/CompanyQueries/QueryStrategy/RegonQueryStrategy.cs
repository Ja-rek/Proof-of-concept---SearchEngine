using Aveneo.SearchEngine.Infrastructure.DataModel;
using NHibernate;

namespace Aveneo.SearchEngine.Infrastructure.CompanyQueries.QueryStrategy
{
    internal class RegonOrKsrQueryStrategy : IQueryStrategy
    {
        public void WhereValueExist(ref IQueryOver<CompanyData, CompanyData> query, long predicate)
        {
            if (predicate == 9) query.Where(x => x.Regon == predicate);
        }
    }
}
