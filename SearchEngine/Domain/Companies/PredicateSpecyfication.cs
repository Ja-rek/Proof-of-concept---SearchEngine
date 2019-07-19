using System.Text.RegularExpressions;

namespace Aveneo.SearchEngine.Domain.Companies
{
    public class PredicateSpecyfication
    {
        public static bool Valid(string predicate)
        {
            var machNumber = Regex.Match(
                predicate.Replace(" ", string.Empty), 
                @"(\A(\w{2})*\d{3}-\d{3}-\d{2}-\d{2}\Z|\A(\w{2})*\d{10}\Z|\A\d{9}\Z)");

            return machNumber.Success;
        }
    }
}
