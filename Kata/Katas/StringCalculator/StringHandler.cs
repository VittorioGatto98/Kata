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
        public static int[] GetNumbersFromString(string str)
        {
            string strReplaced = str.Replace("\n", ",");

            if (strReplaced.EndsWith(","))
                throw new FormatException("La stringa fininsce con il separatore");

            string[] strSplitted =
                strReplaced.Split(',', StringSplitOptions.RemoveEmptyEntries);

            if (strSplitted.Length == 0)
                return new int[0];

            int[] numbersToSum = new int[strSplitted.Length];

            for (int i = 0; i < strSplitted.Length; i++)
                numbersToSum[i] = Convert.ToInt32(strSplitted[i]);

            return numbersToSum;
        }
    }
}
