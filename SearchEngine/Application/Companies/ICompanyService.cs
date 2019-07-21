using Monads;

namespace Aveneo.SearchEngine.Application.Companies
{
    public interface ICompanyService
    {
        Maybe<CompanyResult> GetCompanyByPredicateOf(long id);
    }
}
