using Kata.Katas.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Katas.StringCalculator
{
    public class StringCalculator
    {
        public decimal AddNumbersInString(string str)
        {
            decimal[] numberToSum = StringHandler.GetNumbersFromString(str);
            return Calculator.GetSum(numberToSum);
        }

    }
}
