using Aveneo.SearchEngine.Infrastructure.DataModel;
using NHibernate;

namespace Aveneo.SearchEngine.Infrastructure.CompanyQueries
{
    internal interface IQueryStrategy
    {
        void WhereValueExist(ref IQueryOver<CompanyData, CompanyData> query, long predicate);
    }
}
