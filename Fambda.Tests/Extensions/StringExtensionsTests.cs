using System;
using Fambda.Extensions;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("not empty", false)]
        [InlineData("", true)]
        public void IsEmptyShouldReturnExpectedResult(string str, bool boolean)
        {
            // Arrange
            var expected = boolean;

            // Act
            var result = str.IsEmpty();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("not white space", false)]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData("  ", true)]
        public void IsWhiteSpaceShouldReturnExpectedResult(string str, bool boolean)
        {
            // Arrange
            var expected = boolean;

            // Act
            var result = str.IsWhiteSpace();

            // Assert
            result.Should().Be(expected);
        }


        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" str", true)]
        [InlineData("  str", true)]
        [InlineData("   str", true)]
        public void HasLeadingSpaceShouldReturnExpectedResult(string str, bool boolean)
        {
            // Arrange
            var expected = boolean;

            // Act
            var result = str.HasLeadingSpace();

            // Assert
            result.Should().Be(expected);
        }


        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("str ", true)]
        [InlineData("str  ", true)]
        [InlineData("str   ", true)]
        public void HasTrailingSpaceShouldReturnExpectedResult(string str, bool boolean)
        {
            // Arrange
            var expected = boolean;

            // Act
            var result = str.HasTrailingSpace();

            // Assert
            result.Should().Be(expected);
        }
    }
}
