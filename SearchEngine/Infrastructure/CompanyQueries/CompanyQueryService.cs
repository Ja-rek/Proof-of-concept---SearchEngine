using System.Collections.Generic;
using NHibernate;
using Monads;
using static Monads.MaybeFactory;
using NHibernate.SqlCommand;
using Aveneo.SearchEngine.Application.Companies;
using Aveneo.SearchEngine.Infrastructure.DataModel;

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

        public Maybe<CompanyResult> GetCompanyByPredicateOf(long numberToSearch)
        {
            foreach (var strategy in this.strategies)
            {
                if (strategy.IsCorrectNumber(numberToSearch))
                {
                    var companyData = this.session.QueryOver<CompanyData>()
                        .Where(strategy.WherePredicate(numberToSearch))
                        .JoinQueryOver(x => x.Address, JoinType.InnerJoin)
                        .SingleOrDefault();

                    if (companyData != null)
                    {
                        return new CompanyResult(companyData.Id, 
                            companyData.Name, 
                            companyData.Address.Street, 
                            companyData.Address.SuiteOrApartament,
                            companyData.Address.PostCode,
                            companyData.Address.City);
                    }
                }
            }

            return Nothing;
        }
    }
}
