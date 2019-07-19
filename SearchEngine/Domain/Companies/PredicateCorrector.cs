using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aveneo.SearchEngine.Domain.Companies
{
    public class PredicateCorrector
    {
        public static int Correct(string predicate)
        {
            var numbers = string.Join(string.Empty, 
                Regex.Matches(predicate, @"\d").OfType<Match>().Select(m => m.Value));

            if (!numbers.Any()) throw new ApplicationException("The string must contain any number.");

            return int.Parse(numbers);
        }
    }
}
