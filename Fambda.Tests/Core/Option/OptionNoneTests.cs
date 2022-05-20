using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class OptionNoneTests
    {
        [Fact]
        public void Constructor_ReturnsDefaultOptionNone()
        {
            // Arrange
            var expected = default(OptionNone);

            // Act
            var result = new OptionNone();

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void GetHashCode_ReturnsZero()
        {
            // Arrange
            var optionNone = new OptionNone();

            // Act
            var result = optionNone.GetHashCode();

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void ToString_ReturnsExpectedRepresentation()
        {
            // Arrange
            var expectedResult = "None";
            var optionNone = new OptionNone();

            // Act
            var result = optionNone.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
