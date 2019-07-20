using Aveneo.Common.Domain.Events;
using Aveneo.SearchEngine.Domai.Statisticsn;
using Aveneo.SearchEngine.Domain.Companies;
using Monads;
using static Monads.MaybeFactory;

namespace Aveneo.SearchEngine.Application.Companies
{
    internal class CompanySearchService
    {
        private readonly ICompanyService companyService;
        private readonly EventPublisher publisher;

        public CompanySearchService(ICompanyService companyService, EventPublisher publisher)
        {
            this.companyService = companyService;
            this.publisher = publisher;
        }

        public Maybe<CompanyResult> FindCompany(FindCompanyCommand command)
        {
            var headers = HttpHeadersFactory.HttpHeaders(command.Headers);

            if (PredicateSpecyfication.Valid(command.Predicate))
            {
                var predicate = PredicateCorrector.Correct(command.Predicate);

                var maybeCompany = this.companyService.GetCompanyByPredicate(predicate);

                maybeCompany.Do(
                    just: company => this.publisher.Publish(new FoundCompanyEvent(predicate, company.Id, headers)),
                    nothing:() => this.publisher.Publish(new NotFonudCompanyEvent(predicate, headers)));;

                return maybeCompany;
            }

            this.publisher.Publish(new InvalidCompanyPredicateEvent(command.Predicate, headers));

            return Nothing;
        }
    }
}
