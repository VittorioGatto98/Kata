using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Katas.Common
{
    internal static class Calculator
    {
        public static decimal GetSum(params decimal[] numberToSum)
        {
            decimal sum = 0;

            foreach (decimal number in numberToSum)
                sum += number;

            return sum;
        }
    }
}
