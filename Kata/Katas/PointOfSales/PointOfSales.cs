using Kata.Katas.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata.Katas.PointOfSales
{
    public class PointOfSales
    {
        public decimal sum = 0;

        public decimal GetPriceFromBarCode(string barCode)
        {
            decimal price = 0;

            if (string.IsNullOrWhiteSpace(barCode))
                throw new FormatException("Error: empty barcode");
            
            string? strPrice = GetValueFromCatalog(barCode);

            if (string.IsNullOrWhiteSpace(strPrice))
                throw new KeyNotFoundException("Error: barcode not found");

            if (!decimal.TryParse(strPrice, CultureInfo.InvariantCulture, out price))
                throw new FormatException("Error: price string wasn't in correct format");

            return price;
        }

        private static string? GetValueFromCatalog(string barCode)
        {
            ResourceManager rm = new ResourceManager("Kata.Katas.PointOfSales.Catalog", Assembly.GetExecutingAssembly());
            string? strPrice = rm.GetString(barCode, CultureInfo.CurrentCulture);
            return strPrice;
        }

        public decimal GetTotalPrice(params string[] barCode)
        {
            foreach(var code in  barCode) 
            {
                sum += Calculator.GetSum(GetPriceFromBarCode(code));
            }

            return sum;
        }
    }
}
