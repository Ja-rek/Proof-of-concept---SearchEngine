using System.Collections.Generic;
using System.Linq;
using Aveneo.SearchEngine.Domain.Statistics;

namespace Aveneo.SearchEngine.Domai.Statisticsn
{
    internal class HttpHeadersFactory
    {
        public IEnumerable<HttpHeader> HttpHeaders(Dictionary<string, string> headers)
        {
            return headers.Select(x => new HttpHeader(x.Key, x.Value));
        }
    }
}
