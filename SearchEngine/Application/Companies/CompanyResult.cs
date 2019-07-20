namespace Aveneo.SearchEngine.Application.Companies
{
    public class CompanyResult
    {
        internal CompanyResult(int id, string name, string street, string suiteOrApartament, int postCode, string city)
        {
            Id = id;
            Name = name;
            Street = street;
            SuiteOrApartament = suiteOrApartament;
            PostCode = postCode;
            City = city;
        }

        public int Id { get; }
        public string Name { get; }
        public string Street { get; }
        public string SuiteOrApartament { get; }
        public int PostCode { get; }
        public string City { get; }
    }
}
