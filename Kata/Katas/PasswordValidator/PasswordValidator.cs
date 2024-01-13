using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata.Katas.PasswordValidator
{
    public class PasswordValidator
    {
        public ValidationResult Check(string password)
        {
            ValidationResult result = new ValidationResult();

            if (!CheckLengthPasswordMoreThanEight(password))
                result.AddToValidationResult("ERR001 - Password must be at least 8 character.");

            if (RegexValidator.CountCharacters(password, "\\d") < 1)
                result.AddToValidationResult("ERR002 - The password must contain at least 2 numbers.");

            if (RegexValidator.CountCharacters(password, "[A-Z]") < 1)
                result.AddToValidationResult("ERR003 - The password must contain at least 1 capital letter.");

            if (RegexValidator.CountCharacters(password, "\\W") < 1)
                result.AddToValidationResult("ERR004 - The password must contain at least 1 special character.");

            return result;
        }

        public bool CheckLengthPasswordMoreThanEight(string password)
        {
            return password.Length > 7;
        }
    }
}
