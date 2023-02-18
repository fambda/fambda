using FluentAssertions;
using Xunit;

namespace Fambda.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("not empty", false)]
        [InlineData("", true)]
        public void IsEmpty_ReturnsExpectedResult(string str, bool boolean)
        {
            // Arrange
            var expected = boolean;

            // Act
            var result = str.IsEmpty();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("not white space", false)]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData("  ", true)]
        public void IsWhiteSpace_ReturnsExpectedResult(string str, bool boolean)
        {
            // Arrange
            var expected = boolean;

            // Act
            var result = str.IsWhiteSpace();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("", false)]
        [InlineData(" str", true)]
        [InlineData("  str", true)]
        [InlineData("   str", true)]
        public void HasLeadingSpace_ReturnsExpectedResult(string str, bool boolean)
        {
            // Arrange
            var expected = boolean;

            // Act
            var result = str.HasLeadingSpace();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("", false)]
        [InlineData("str ", true)]
        [InlineData("str  ", true)]
        [InlineData("str   ", true)]
        public void HasTrailingSpace_ReturnsExpectedResult(string str, bool boolean)
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
