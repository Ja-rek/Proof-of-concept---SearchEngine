using System.Collections.Generic;
using NHibernate;
using Aveneo.SearchEngine.Application.Companies;
using Aveneo.SearchEngine.Infrastructure.DataModel;
using Monads;
using static Monads.MaybeFactory;
using NHibernate.SqlCommand;

namespace Aveneo.SearchEngine.Infrastructure.CompanyQueries
{
    internal class CompanyQueryService : ICompanyService
    {
        private readonly ISession session;
        private readonly IEnumerable<IQueryStrategy> strategies;

        public CompanyQueryService(ISession session, IEnumerable<IQueryStrategy> strategies)
        {
            this.session = session;
            this.strategies = strategies;
        }

        public Maybe<CompanyResult> GetCompanyByPredicate(long predicate)
        {
            var query = this.session.QueryOver<CompanyData>();

            foreach (var strategy in this.strategies)
            {
                strategy.WhereValueExist(ref query, predicate);
            }

            query.JoinQueryOver(x => x.Address, JoinType.LeftOuterJoin);

            var companyData = query.SingleOrDefault();

            if (companyData == null) return Nothing;

            return new CompanyResult(companyData.Id, 
                companyData.Name, 
                companyData.Address.Street, 
                companyData.Address.SuiteOrApartament,
                companyData.Address.PostCode,
                companyData.Address.City);
        }
    }
}
