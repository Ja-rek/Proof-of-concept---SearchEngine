using Microsoft.AspNetCore.Mvc;
using Monads.Extensions.Unsafe;
using Aveneo.SearchEngine.Application.Companies;

namespace Aveneo.SearchEngine.Web.Companies
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanySearchService service;

        public CompanyController(CompanySearchService service)
        {
            this.service = service;
        }

        [HttpGet("{predicate}")]
        public ActionResult<CompanyResource> Get(string predicate)
        {
            var headers = HeadersFactory.Headers(Request);

            var maybeCompany= this.service.FindCompany(new FindCompanyCommand(predicate, headers));

            if (maybeCompany.HasValue()) return new CompanyResource(maybeCompany.Value());

            return StatusCode(204);
        }
    }
}
