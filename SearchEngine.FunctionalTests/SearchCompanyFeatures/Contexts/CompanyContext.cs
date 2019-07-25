using System;
using System.Linq;
using System.Text.RegularExpressions;
using Aveneo.SearchEngine.Common;
using Aveneo.SearchEngine.Infrastructure.DataModel;
using NHibernate;
using NUnit.Framework;
using RestSharp;

namespace Aveneo.SearchEngine.FunctionalTests
{
    public class CompanyContext
    {
        private string number;
        private readonly RestClient restClient;
        private readonly ISession session;
        private IRestResponse<CompanyResource> response;

        public CompanyContext(RestClient restClient, ISession session)
        {
            this.restClient = restClient;
            this.session = session;
        }

        public void Given_NIP_number_taht_exist_in_database_in_the_format_like_00_000_000_00()=> this.number = "40-000-000-00";
        public void Given_NIP_number_taht_exist_in_database_in_the_format_like_0000000000()=> this.number = "4000000000";
        public void Given_NIP_number_taht_exist_in_database_in_the_format_like_PL_0000000()=> this.number = "Pl 4000000000";
        public void Given_NIP_number_taht_exist_in_database_in_the_format_like_PL0000000()=> this.number = "PL4000000000";
        public void Given_NIP_number_taht_exist_in_database_in_the_format_like_PL_00_000_000_00()=> this.number = "pl 40-000-000-00";
        public void Given_NIP_number_taht_exist_in_database_in_the_format_like_PL00_000_000_00()=> this.number = "PL40-000-000-00";
        public void Given_REGON_number_taht_exist_in_database()=> this.number = "300000000";
        public void Given_KSR_number_taht_exist_in_database() => this.number = "2000000000";

        public void Given_KSR_number_taht_not_exist_in_database() => this.number = "123456789";
        public void Given_NIP_number_taht_not_exist_in_database()=> this.number = "123456789";
        public void Given_REGON_number_taht_not_exist_in_database()=> this.number = "123456789";

        public void Given_incorrect_number_format()=> this.number = "4564564654654sdf456";

        public void When_call_endpoint_company_with_given_number()
        {
            var request = new RestRequest($"company/{this.number}", Method.GET);
            this.response = this.restClient.Execute<CompanyResource>(request);
        }

        public void And_recived_company_has_no_property_that_is_empty_or_zero()
        {
            var company = this.response.Data;

            Assert.IsNotEmpty(company.Name);
            Assert.IsNotEmpty(company.City);
            Assert.IsNotEmpty(company.Street);
            Assert.IsNotEmpty(company.SuiteOrApartament);
            Assert.NotZero(company.PostCode);
        }

        public void And_the_request_has_saved_in_database_with_stauts_found()
        {
            CheckStatistic(Status.Found);
            RemoveStatistic();
        }

        public void And_the_request_has_saved_in_database_with_stauts_not_found()
        {
            CheckStatistic(Status.NotFound);
            RemoveStatistic();
        }

        public void And_the_request_has_saved_in_database_with_stauts_invalid_predicate()
        {
            CheckStatistic(Status.InvalidValueToSearch, filter: false);
            RemoveStatistic();
        }

        public void Then_the_status_code_is_200()
        {
            Assert.True((int)this.response.StatusCode == 200);
        }

        public void Then_status_code_is_204()
        {
            Assert.True((int)this.response.StatusCode == 204);
        }

        private void CheckStatistic(Status status, bool filter = true)
        {
            var number = this.number;

            if (filter)
            {
                number = string.Join(string.Empty, 
                    Regex.Matches(this.number, @"\d").OfType<Match>().Select(m => m.Value));
            }

            var count = this.session.QueryOver<CompanyStatisticData>()
                .Where(x => x.ValueToSearch == number && x.Status == status)
                .RowCount();

            Assert.NotZero(count);
        }

        private void RemoveStatistic()
        {
            this.session.Delete ($"from {nameof(CompanyStatisticData)}");
            this.session.Flush();
        }
    }
}
