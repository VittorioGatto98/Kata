using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Kata.Katas.FizzBuzz;

namespace Kata.Test
{
    /// <summary>
    /// TDD : 
    /// 
    /// 1) First create the test class, then the test method inside.
    /// 2) Create the real class and method with NoImplementedException, then run tests(they will obviously return test fail)
    /// 3) Create logic inside real method to get test succeeded in all cases.
    /// 4) Refactor method.
    /// </summary>

    public class FizzBuzzTests
    {
        private readonly FizzBuzz _sut = new FizzBuzz();

        [Theory]
        [InlineData("Fizz", 9)]
        [InlineData("Buzz", 5)]
        [InlineData("FizzBuzz", 15)]
        [InlineData("34", 34)]
        public void CheckIfNumberIsEqualToFizzBuzzOrNumber(string expected, int number)
        {
            string result = _sut.GetFizzBuzzValue(number);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Fizz", 5)]
        [InlineData("Fizz", 4)]
        [InlineData("Buzz", 3)]
        [InlineData("Buzz", 4)]
        [InlineData("FizzBuzz", 7)]
        [InlineData("FizzBuzz", 33)]
        [InlineData("33", 34)]
        public void CheckIfNumberIsNotEqualToFizzBuzzOrNumber(string expected, int number)
        {
            string result = _sut.GetFizzBuzzValue(number);

            result.Should().NotBe(expected);
        }

    }
}
