using FluentAssertions;
using Kata.Katas.SearchFunctionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Kata.Test
{
    public class SearchFunctionalityTest
    {
        private readonly SearchFunctionality _sut;

        public SearchFunctionalityTest()
        {
            _sut = new SearchFunctionality();
        }

        [Fact]
        public void IfStringIsLessThantTwoCharactersThenReturnNull()
        {
            string search = "P";

            var result = _sut.Search(search);

            result.Count.Should().BeLessThanOrEqualTo(0);
        }

        [Theory]
        [InlineData("Pa", 1)]
        [InlineData("Lon", 1)]
        [InlineData("Hon", 1)]
        public void IfGivenStringIsMoreOrEqualThanTwoCharsThenReturnCitiesStartingWithThat(string search, int expectedCounts)
        {
            var result = _sut.Search(search);

            result.Should().HaveCountGreaterThanOrEqualTo(expectedCounts);
        }

        [Theory]
        [InlineData("pa", 0)] // Case 3: The search functionality should be case insensitive
        [InlineData("Pa", 1)] 
        [InlineData("lon", 0)]
        [InlineData("Hon", 1)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("ape",1)] // Case 4: "The search functionality should work also when the search text is just a part of a city name"
        public void SearchWithStringShouldBeCaseInsensitive(string search, int expectedCounts)
        {
            var result = _sut.Search(search);

            result.Should().HaveCount(expectedCounts);
        }

        //Case 5: if given string is equal to "*", then return all cities.
        [Fact]
        public void SearchAllCitiesWithAsterisk()
        {
            int count = SearchFunctionality.cities.Count();

            var result = _sut.Search("*");
            result.Should().HaveCount(count);
        }
    }
}
