namespace Aveneo.SearchEngine.Infrastructure.DataModel
{
    public class AddressData
    {
        public virtual int Id { get; set; } 
        public virtual string Street { get; set; }
        public virtual string SuiteOrApartament { get; set; }
        public virtual int PostCode { get; set; }
        public virtual string City { get; set; }
    }
}
