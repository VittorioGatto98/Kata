using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata.Katas.PasswordValidator
{
    internal static class RegexValidator
    {
        public static int CountCharacters(string password, string regexRules)
        {
            Regex regx = new Regex(regexRules);

            return regx.Count(password);
        }
    }
}
