using System.Collections.Generic;

namespace Aveneo.SearchEngine.Application.Companies
{
    public class FindCompanyCommand
    {
        public FindCompanyCommand(string filterPredicate, IDictionary<string, string> headers)
        {
            Predicate = filterPredicate;
            Headers = headers;
        }

        public string Predicate { get; }
        public IDictionary<string, string> Headers { get; }
    }
}
