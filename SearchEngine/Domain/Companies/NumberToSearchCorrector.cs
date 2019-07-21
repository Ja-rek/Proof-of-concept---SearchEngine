using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aveneo.SearchEngine.Domain.Companies
{
    public class NumberToSearchCorrector
    {
        public static long Correct(string predicate)
        {
            var numbers = string.Join(string.Empty, 
                Regex.Matches(predicate, @"\d").OfType<Match>().Select(m => m.Value));

            if (!numbers.Any()) throw new ApplicationException("The string must contain any number.");

            return long.Parse(numbers);
        }
    }
}
