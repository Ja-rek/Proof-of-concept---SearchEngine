namespace Aveneo.SearchEngine.Infrastructure.DataModel
{
    internal class CompanyData
    {
        public virtual int Id { get; set; }
        public virtual int Nip { get; set; }
        public virtual int Regon { get; set; }
        public int Ksr { get; set; }
        public virtual string Name { get; set; }
        public virtual AddressData Address { get; set; }
    }
}
