using System.Collections.Generic;
using System.Linq;
using Aveneo.SearchEngine.Domain.Statistics;

namespace Aveneo.SearchEngine.Domain.Statisticsn
{
    internal class HttpHeadersFactory
    {
        public static IEnumerable<HttpHeader> HttpHeaders(IDictionary<string, string> headers)
        {
            return headers.Select(x => new HttpHeader(x.Key, x.Value));
        }
    }
}
