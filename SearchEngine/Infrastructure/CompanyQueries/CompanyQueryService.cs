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

        public Maybe<CompanyResult> GetCompanyByPredicate(int predicate)
        {
            var query = this.session.QueryOver<CompanyData>();

            foreach (var strategy in this.strategies)
            {
                strategy.WhereValueExist(ref query, predicate);
            }

            query.JoinQueryOver(x => x.Adress, JoinType.LeftOuterJoin);

            var companyData = query.SingleOrDefault();

            if (companyData == null) return Nothing;

            return new CompanyResult(companyData.Id, 
                companyData.Name, 
                companyData.Adress.Street, 
                companyData.Adress.SuiteOrApartament,
                companyData.Adress.PostCode,
                companyData.Adress.City);
        }
    }
}
