using Monads;

namespace Aveneo.SearchEngine.Application.Companies
{
    public interface ICompanyService
    {
        Maybe<CompanyResult> GetCompanyByPredicate(long id);
    }
}
