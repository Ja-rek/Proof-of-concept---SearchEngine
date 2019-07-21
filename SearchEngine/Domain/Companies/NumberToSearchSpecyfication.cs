using System.Text.RegularExpressions;

namespace Aveneo.SearchEngine.Domain.Companies
{
    public class NumberToSearchSpecyfication
    {
        public static bool Valid(string numberToSearch)
        {
            var machNumber = Regex.Match(
                numberToSearch.Replace(" ", string.Empty).Replace("-", string.Empty), 
                @"(\A(\w{2})*\d{10}\Z|\A\d{9}\Z)");

            return machNumber.Success;
        }
    }
}
