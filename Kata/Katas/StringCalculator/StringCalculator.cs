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
        //public decimal GetSum(string str, string[] separator)
        //{
        //    decimal[] numbers = StringHandler.GetNumbersFromString(str, separator);
        //    decimal sum = 0;

        //    if(numbers.Length == 0)
        //        return 0;

        //    decimal[] negativeNumbers = numbers.Where(x => x < 0).ToArray();

        //    if(negativeNumbers.Length > 0)
        //    {
        //        string messageException = $"Negatives not allowed: ";

        //        for(int i = 0; i  < negativeNumbers.Length; i++)
        //        {
        //            messageException += $"{negativeNumbers[i]}";

        //            if (i != negativeNumbers.Length - 1)
        //                messageException += " ; ";
        //        }

        //        throw new Exception(messageException);
        //    }

        //    foreach(decimal number in numbers)
        //        sum += number;

        //    return sum;
        //}


        public int Add(string str)
        {
            int sum = 0;
            int[] numberToSum = StringHandler.GetNumbersFromString(str);

            foreach(int number in numberToSum)
                sum += number;

            return sum;
        }

    }
}
