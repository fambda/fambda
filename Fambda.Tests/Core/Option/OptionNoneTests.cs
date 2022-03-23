using FluentAssertions;
using Xunit;

namespace Fambda
{
    public class OptionNoneTests
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
        public void Equals_OptionNone_ReturnsTrue()
        {
            // Arrange
            var first = new OptionNone();
            var second = new OptionNone();

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_Object_ReturnsFalse()
        {
            // Arrange
            var first = new OptionNone();
            object second = "not an OptionNone";

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_Object_ReturnsTrue()
        {
            // Arrange
            var first = new OptionNone();
            var second = new OptionNone();

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
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
