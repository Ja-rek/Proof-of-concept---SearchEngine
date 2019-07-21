using System;
using System.Collections.ObjectModel;
using AutoFixture;
using Aveneo.Common.Infrastructure.Persistence;
using Aveneo.SearchEngine.Infrastructure.DataModel;
using Newtonsoft.Json;

namespace DatabaseSeed
{
    class Program
    {
        static void Main(string[] args)
        {
            var fixture = new Fixture();

            var numbers = new (long Nip, long Ksr, int Regon)[]
            {
                (1000000000, 2000000000, 300000000),
                (4000000000, 4000000000, 600000000),
                (7000000000, 8000000009, 900000000),
            };

            var companies = new Collection<CompanyData>();

            using(var session = SessionFactory.Session(m => 
                    m.FluentMappings.AddFromAssemblyOf<CompanyData>(), createDb: true))
            using(var transaction = session.BeginTransaction())
            {
                foreach (var number in numbers)
                {
                    var company =new CompanyData 
                    { 
                        Nip = number.Nip, 
                        Ksr = number.Ksr, 
                        Regon = number.Regon, 
                        Name = fixture.Create<string>(),
                        Address = fixture.Build<AddressData>().Without(x => x.Id).With(x => x.PostCode, 12345).Create()
                    };
                                         
                    session.Save(company);

                    companies.Add(company);
                }

                transaction.Commit();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Added: ");
                Console.WriteLine(JsonConvert.SerializeObject(companies, Formatting.Indented));
            }
        }
    }
}
