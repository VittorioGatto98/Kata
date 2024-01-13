using FluentAssertions;
using Kata.Katas.PasswordValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Kata.Test
{
    public class PasswordValidatorTest
    {
        private readonly PasswordValidator _sut;
        private ValidationResult result;

        public PasswordValidatorTest()
        {
            _sut = new PasswordValidator();
        }

        [Theory]
        [InlineData("A12345678#")]
        [InlineData("A123456789#")]
        public void PasswordIsMoreOrEqualThanEightCharacters(string password)
        {
            result = _sut.Check(password);
            
            result.statusResult.Should().BeTrue();
        }

        [Theory]
        [InlineData("123456")]
        public void PasswordIsLessThanEightCharacters(string password)
        {
            result = _sut.Check(password);

            result.Should().Match<ValidationResult>((x) =>
                            !x.statusResult &&
                             x.errorMessages.Contains("ERR001"));
        }

        [Theory]
        [InlineData("abcdefghil")]
        public void PasswordDoesNotContainsAtLeastTwoNumbers(string password)
        {
            result = _sut.Check(password);

            result.Should().Match<ValidationResult>((x) =>
                !x.statusResult &&
                 x.errorMessages.Contains("ERR002"));
        }

        [Theory]
        [InlineData("abc")]
        public void PasswordDoesNotContainsAtLeastEightCharactersAndTwoNumbers(string password)
        {
            result = _sut.Check(password);

            result.Should().Match<ValidationResult>((x) =>
                !x.statusResult &&
                 x.errorMessages.Contains("ERR001") &&
                 x.errorMessages.Contains("ERR002") );
        }

        [Theory]
        [InlineData("abc")]
        public void PasswordDoesNotContainCapitalLetter(string password)
        {
            result = _sut.Check(password);

            result.Should().Match<ValidationResult>((x) =>
                !x.statusResult &&
                 x.errorMessages.Contains("ERR003"));
        }

        [Theory]
        [InlineData("A123456789")]
        public void PasswordDoesNotContainSpecialCharacter(string password)
        {
            result = _sut.Check(password);

            result.Should().Match<ValidationResult>((x) =>
                !x.statusResult &&
                 x.errorMessages.Contains("ERR004"));
        }

    }
}
