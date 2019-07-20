using Aveneo.SearchEngine.Infrastructure.DataModel;
using NHibernate;

namespace Aveneo.SearchEngine.Infrastructure.CompanyQueries.QueryStrategy
{
    internal class NipOrKsrQueryStrategy : IQueryStrategy
    {
        public void WhereValueExist(ref IQueryOver<CompanyData, CompanyData> query, long predicate)
        {
            if (predicate == 10)
            {
                query.Where(x => x.Nip == predicate || x.Ksr == predicate);
            }
        }
    }
}
