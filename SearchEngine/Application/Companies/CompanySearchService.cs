using Aveneo.Common.Domain.Events;
using Aveneo.SearchEngine.Domain.Statisticsn;
using Aveneo.SearchEngine.Domain.Companies;
using Monads;
using static Monads.MaybeFactory;

namespace Aveneo.SearchEngine.Application.Companies
{
    public class CompanySearchService
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

            if (NumberToSearchSpecyfication.Valid(command.NumberToSearch))
            {
                var numberToSearch = NumberToSearchCorrector.Correct(command.NumberToSearch);

                var maybeCompany = this.companyService.GetCompanyByPredicateOf(numberToSearch);

                maybeCompany.Do(
                    just: company => this.publisher.Publish(new FoundCompanyEvent(numberToSearch, company.Id, headers)),
                    nothing:() => this.publisher.Publish(new NotFonudCompanyEvent(numberToSearch, headers)));;

                return maybeCompany;
            }

            this.publisher.Publish(new InvalidCompanyPredicateEvent(command.NumberToSearch, headers));

            return Nothing;
        }
    }
}
