using NUnit.Framework;
using Aveneo.SearchEngine.Application.Companies;
using System.Collections.Generic;
using Aveneo.SearchEngine.Infrastructure.CompanyQueries;
using System.Linq;
using Aveneo.Common.Domain.Events;
using Aveneo.SearchEngine.Domain.Companies;

namespace Aveneo.SearchEngine.IntegrationTest
{
    public class ContainerIOCTests
    {
        [Test]
        public void ContainerIOCConfig_CanResoveApplicationServices()
        {
            ServiceLocator.Resolve<CompanySearchService>();
            ServiceLocator.Resolve<IHandleEvent<FoundCompanyEvent>>();

            var strategies = ServiceLocator.Resolve<IEnumerable<IQueryStrategy>>();

            Assert.AreEqual(2, strategies.Count());
        }
    }
}
