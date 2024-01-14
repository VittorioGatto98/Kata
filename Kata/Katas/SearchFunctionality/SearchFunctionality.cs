using Kata.Katas.StringCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Katas.SearchFunctionality
{
    public class SearchFunctionality
    {
        public static IEnumerable<string> cities =>
        new List<string> { "Paris", "Budapest", "Skopje", "Rotterdam", "Valencia", "Vancouver", "Amsterdam", "Vienna",
                "Sydney", "New York City", "London", "Bangkok", "Hong Kong", "Dubai", "Rome", "Istanbul" };

        public List<string>? Search(string search)
        {
            List<string> result;

            if (search == "*")
                return cities.ToList();

            if (string.IsNullOrWhiteSpace(search) || !StringHandler.CheckIfStringLegthIsMoreOrEqualThan(search, 2))
                return result = new List<string>();

             result = [.. cities.Where(x => x.Contains(search))];

            return result;
        }
    }
}
