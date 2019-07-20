using System;
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

            var companies = new CompanyData[] 
            {
                new CompanyData 
                { 
                    Nip = 1234567890, 
                    Ksr = 2234567890, 
                    Regon = 323456789, 
                    Name = fixture.Create<string>(),
                    Address = fixture.Build<AddressData>().Without(x => x.Id).With(x => x.PostCode, 12345).Create()
                },
                new CompanyData 
                { 
                    Nip = 5234567890, 
                    Ksr = 6234567890, 
                    Regon = 723456789, 
                    Name = fixture.Create<string>(),
                    Address = fixture.Build<AddressData>().Without(x => x.Id).With(x => x.PostCode, 12345).Create()
                },
                new CompanyData 
                { 
                    Nip = 5234567890, 
                    Ksr = 6234567890, 
                    Regon = 723456789, 
                    Name = fixture.Create<string>(),
                    Address = fixture.Build<AddressData>().Without(x => x.Id).With(x => x.PostCode, 12345).Create()
                },
                new CompanyData 
                { 
                    Nip = 8234567890, 
                    Ksr = 9234567890, 
                    Regon = 993456789, 
                    Name = fixture.Create<string>(),
                    Address = fixture.Build<AddressData>().Without(x => x.Id).With(x => x.PostCode, 12345).Create()
                },
            };

            using(var session = SessionFactory.Session(m => 
                    m.FluentMappings.AddFromAssemblyOf<CompanyData>(), createDb: true))

            using(var transaction = session.BeginTransaction())
            {
                foreach (var company in companies)
                {
                    session.Save(company);
                }

                transaction.Commit();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Added: ");
                Console.WriteLine(JsonConvert.SerializeObject(companies, Formatting.Indented));
            }
        }
    }
}
