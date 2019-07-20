using Monads;

namespace Aveneo.SearchEngine.Application.Companies
{
    internal interface ICompanyService
    {
        Maybe<CompanyResult> GetCompanyByPredicate(long id);
    }
}
