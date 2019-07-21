using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Aveneo.SearchEngine.Web.Companies
{
    internal class HeadersFactory
    {
        public static IDictionary<string, string> Headers(HttpRequest request) 
        {
            return request.Headers.ToDictionary(a => a.Key, a => string.Join("; ", a.Value));
            
        }
    }
}
