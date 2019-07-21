using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.NUnit3;

namespace Aveneo.SearchEngine.FunctionalTests
{
    [FeatureDescription("As a website user i want to find a company by KSR number.")]
    public class FindCompanyByKsr : FeatureFixture
    {
        [Scenario]
        public void Call_Company_Endpoint_With_The_KSR_That_Exist_In_Database()
        {
            Runner.WithContext<CompanyContext>().RunScenario(
                    _ => _.Given_KSR_number_taht_exist_in_database(),
                    _ => _.When_call_endpoint_company_with_given_number(),
                    _ => _.Then_the_status_code_is_200(),
                    _ => _.And_recived_company_has_no_property_that_is_empty_or_zero(),
                    _ => _.And_the_request_has_saved_in_database_with_stauts_found());
        }

        [Scenario]
        public void Call_Company_Endpoint_With_The_KSR_That_Not_Exist_In_Database()
        {
            Runner.WithContext<CompanyContext>().RunScenario(
                    _ => _.Given_KSR_number_taht_not_exist_in_database(),
                    _ => _.When_call_endpoint_company_with_given_number(),
                    _ => _.Then_status_code_is_204(),
                    _ => _.And_the_request_has_saved_in_database_with_stauts_not_found());
        }

        [Scenario]
        public void Call_Company_Endpoint_With_The_KSR_That_Has_Invalid_Format()
        {
            Runner.WithContext<CompanyContext>().RunScenario(
                    _ => _.Given_incorrect_number_format(),
                    _ => _.When_call_endpoint_company_with_given_number(),
                    _ => _.Then_status_code_is_204(),
                    _ => _.And_the_request_has_saved_in_database_with_stauts_invalid_predicate());
        }
    }
}
