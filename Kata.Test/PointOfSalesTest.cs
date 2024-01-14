using FluentAssertions;
using Kata.Katas.PointOfSales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Test
{
    public class PointOfSalesTest
    {
        private readonly PointOfSales _sut;
        public PointOfSalesTest() 
        {
            _sut = new PointOfSales();
        }

        [Theory]
        [InlineData("12345", 7.25)]
        [InlineData("23456", 12.50)]
        public void GetPriceFromBarcode(string barCode, decimal expected)
        {
            decimal result = _sut.GetTotalPrice(barCode);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void GetFormatExceptionWhenBarCodeIsNullOrEmpty(string barCode)
        {
            Action action = () => { _sut.GetTotalPrice(barCode); };

            action.Should().Throw<FormatException>().Which.Message.Should().Be("Error: empty barcode");
        }

        [Theory]
        [InlineData("22222")]
        public void GetFormatExceptionWhenBarCodeIsNotFound(string barCode)
        {
            Action action = () => { _sut.GetTotalPrice(barCode); };

            action.Should().Throw<FormatException>();
        }

        [Theory]
        [InlineData("78999")]
        [InlineData("A1234")]
        public void GetKeyNotFoundExceptionWhenBarCodeContainsLetters(string barCode)
        {
            Action action = () => { _sut.GetTotalPrice(barCode); };

            action.Should().Throw<KeyNotFoundException>().Which.Message.Should().Be("Error: barcode not found");
        }

        [Theory]
        [InlineData("12345", "23456", 19.75)]
        public void GetTotalPriceFromMultipleItems(string barCode1, string barCode2, decimal expected)
        {
            var result = _sut.GetTotalPrice(barCode1, barCode2);

            result.Should().Be(expected);
        }

    }
}
