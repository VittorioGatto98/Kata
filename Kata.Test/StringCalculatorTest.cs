using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Kata.Katas.StringCalculator;

namespace Kata.Test
{
    public class StringCalculatorTest
    {
        private readonly StringCalculator _sut;
        private readonly string _splitter = ";";
        private readonly string[] _separator =   { "\n" };
        private int result = 0;
        public StringCalculatorTest() 
        {
            _sut = new StringCalculator();

        }

        [Fact]
        public void GetZero()
        {
            result = _sut.Add(string.Empty);
            
            result.Should().Be(0);
        }

        [Theory]
        [InlineData("3", 3)]
        [InlineData("-5", -5)]
        public void GetSingleNumber(string str, int expected)
        {
            result = _sut.Add(str);
            
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("3,3", 6)]
        [InlineData("-5,3", -2)]
        [InlineData("0,-0", 0)]
        public void GetSumOfTwoNumber(string str, int expected)
        {
            result = _sut.Add(str);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("3,3,3", 9)]
        [InlineData("-5,3,4,9", 11)]
        [InlineData("0,-0,1,4", 5)]
        public void GetSumOfTwoOrMoreNumber(string str, int expected)
        {
            result = _sut.Add(str);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("3\n3", 6)]
        [InlineData("-5,3\n2", 0)]
        [InlineData("0,-0\n9", 9)]
        public void GetSumOfTwoNumberWithNewLine(string str, int expected)
        {
            result = _sut.Add(str);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("3\n4,5,")]
        public void GetFormatExceptionWhenStringEndWithSeparator(string str)
        {
            Action action = () => _sut.Add(str);

            action.Should().Throw<FormatException>();
        }
    }
}
