using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Katas.StringCalculator
{
    internal static class StringHandler
    {
        #region StringCalculator
            public static decimal[] GetNumbersFromString(string str)
            {
                string separator = ",";
                int indexStartForSubstring = 0;

                CheckStartEndString(str, ref separator, ref indexStartForSubstring);

                string strReplaced =
                    ReplaceValueInsideString(str, separator, indexStartForSubstring);
            
                string[] strSplitted = SplitWithSpecifiedSeparator(separator, strReplaced);

                if (strSplitted.Length == 0)
                    return new decimal[0];

                decimal[] numbersToSum = new decimal[strSplitted.Length];

                for (int i = 0; i < strSplitted.Length; i++)
                    numbersToSum[i] = Convert.ToInt32(strSplitted[i]);

                return numbersToSum;
            }

            private static string[] SplitWithSpecifiedSeparator(string separator, string strReplaced)
            {
                return strReplaced.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            }

            private static string ReplaceValueInsideString(string str, string separator, int indexStartForSubstring)
            {
                return str.Substring(indexStartForSubstring)
                                                    .Replace("\n", separator);
            }

            private static void CheckStartEndString(string str, ref string separator, ref int indexStartForSubstring)
            {
                if (str.EndsWith(","))

                    throw new FormatException("La stringa fininsce con il separatore");

                if (str.StartsWith("//"))
                {
                    separator = str.Substring(2, 1);
                    indexStartForSubstring = 3;
                }
            }
        #endregion StringCalculator

        #region SearchFunctionality

        public static bool CheckIfStringLengthIsLessThan(string str, int minLength)
        {
            return (string.IsNullOrWhiteSpace(str) || str.Length < minLength) 
                ? true 
                : false;
        }

        #endregion SearchFunctionality

        #region PointOfSales
        
        #endregion PointOfSales
    }
}
