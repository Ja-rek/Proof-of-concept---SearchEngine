using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.NUnit3;

namespace Aveneo.SearchEngine.FunctionalTests
{
    [FeatureDescription("As a website user I want to find a company by NIP number.")]
    public class FindCompanyByNip : FeatureFixture
    {
        [Scenario]
        public void Call_Company_Endpoint_With_The_NIP_In_A_Format_Like_0000000000_Which_Exist_In_Database()
        {
            Runner.WithContext<CompanyContext>().RunScenario(
                    _ => _.Given_NIP_number_taht_exist_in_database_in_the_format_like_0000000000(),
                    _ => _.When_call_endpoint_company_with_given_number(),
                    _ => _.Then_the_status_code_is_200(),
                    _ => _.And_recived_company_has_no_property_that_is_empty_or_zero(),
                    _ => _.And_the_request_has_saved_in_database_with_stauts_found());
        }

        [Scenario]
        public void Call_Company_Endpoint_With_The_NIP_In_A_Format_Like_00_000_000_00_Which_Exist_In_Database()
        {
            Runner.WithContext<CompanyContext>().RunScenario(
                    _ => _.Given_NIP_number_taht_exist_in_database_in_the_format_like_00_000_000_00(),
                    _ => _.When_call_endpoint_company_with_given_number(),
                    _ => _.Then_the_status_code_is_200(),
                    _ => _.And_recived_company_has_no_property_that_is_empty_or_zero(),
                    _ => _.And_the_request_has_saved_in_database_with_stauts_found());
        }

        [Scenario]
        public void Call_Company_Endpoint_With_The_NIP_In_A_Format_Like_PL0000000_Which_Exist_In_Database()
        {
            Runner.WithContext<CompanyContext>().RunScenario(
                    _ => _.Given_NIP_number_taht_exist_in_database_in_the_format_like_PL0000000(),
                    _ => _.When_call_endpoint_company_with_given_number(),
                    _ => _.Then_the_status_code_is_200(),
                    _ => _.And_recived_company_has_no_property_that_is_empty_or_zero(),
                    _ => _.And_the_request_has_saved_in_database_with_stauts_found());
        }

        [Scenario]
        public void Call_Company_Endpoint_With_The_NIP_In_A_Format_Like_PL_0000000_Which_Exist_In_Database()
        {
            Runner.WithContext<CompanyContext>().RunScenario(
                    _ => _.Given_NIP_number_taht_exist_in_database_in_the_format_like_PL_0000000(),
                    _ => _.When_call_endpoint_company_with_given_number(),
                    _ => _.Then_the_status_code_is_200(),
                    _ => _.And_recived_company_has_no_property_that_is_empty_or_zero(),
                    _ => _.And_the_request_has_saved_in_database_with_stauts_found());
        }

        [Scenario]
        public void Call_Company_Endpoint_With_The_NIP_In_A_Format_Like_PL00_000_000_00_Which_Exist_In_Database()
        {
            Runner.WithContext<CompanyContext>().RunScenario(
                    _ => _.Given_NIP_number_taht_exist_in_database_in_the_format_like_PL00_000_000_00(),
                    _ => _.When_call_endpoint_company_with_given_number(),
                    _ => _.Then_the_status_code_is_200(),
                    _ => _.And_recived_company_has_no_property_that_is_empty_or_zero(),
                    _ => _.And_the_request_has_saved_in_database_with_stauts_found());
        }

        [Scenario]
        public void Call_Company_Endpoint_With_The_NIP_In_A_Format_Like_PL_00_000_000_00_Which_Exist_In_Database()
        {
            Runner.WithContext<CompanyContext>().RunScenario(
                    _ => _.Given_NIP_number_taht_exist_in_database_in_the_format_like_PL_00_000_000_00(),
                    _ => _.When_call_endpoint_company_with_given_number(),
                    _ => _.Then_the_status_code_is_200(),
                    _ => _.And_recived_company_has_no_property_that_is_empty_or_zero(),
                    _ => _.And_the_request_has_saved_in_database_with_stauts_found());
        }

        [Scenario]
        public void Call_Company_Endpoint_With_The_NIP_That_Not_Exist_In_Database()
        {
            Runner.WithContext<CompanyContext>().RunScenario(
                    _ => _.Given_NIP_number_taht_not_exist_in_database(),
                    _ => _.When_call_endpoint_company_with_given_number(),
                    _ => _.Then_status_code_is_204(),
                    _ => _.And_the_request_has_saved_in_database_with_stauts_not_found());
        }

        [Scenario]
        public void Call_Company_Endpoint_With_The_NIP_That_Has_Invalid_Format()
        {
            Runner.WithContext<CompanyContext>().RunScenario(
                    _ => _.Given_incorrect_number_format(),
                    _ => _.When_call_endpoint_company_with_given_number(),
                    _ => _.Then_status_code_is_204(),
                    _ => _.And_the_request_has_saved_in_database_with_stauts_invalid_predicate());
        }
    }
}
