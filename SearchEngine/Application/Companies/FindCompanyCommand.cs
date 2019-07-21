using System.Collections.Generic;

namespace Aveneo.SearchEngine.Application.Companies
{
    public class FindCompanyCommand
    {
        public FindCompanyCommand(string numberToSearch, IDictionary<string, string> headers)
        {
            NumberToSearch = numberToSearch;
            Headers = headers;
        }

        public string NumberToSearch { get; }
        public IDictionary<string, string> Headers { get; }
    }
}
