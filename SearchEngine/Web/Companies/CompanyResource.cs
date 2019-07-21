using Aveneo.SearchEngine.Application.Companies;

namespace Aveneo.SearchEngine.Web.Companies
{
    public class CompanyResource
    {
        internal CompanyResource(CompanyResult companyResult)
        {
            Name = companyResult.Name;
            Street = companyResult.Street;
            SuiteOrApartament = companyResult.SuiteOrApartament;
            PostCode = companyResult.PostCode;
            City = companyResult.City;
        }

        public string Name { get; }
        public string Street { get; }
        public string SuiteOrApartament { get; }
        public int PostCode { get; }
        public string City { get; }
    }
}
