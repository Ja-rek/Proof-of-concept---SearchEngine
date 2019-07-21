namespace Aveneo.SearchEngine.Infrastructure.DataModel
{
    public class CompanyData
    {
        public virtual int Id { get; set; }
        public virtual long Nip { get; set; }
        public virtual int Regon { get; set; }
        public virtual long Ksr { get; set; }
        public virtual string Name { get; set; }
        public virtual AddressData Address { get; set; }
    }
}
