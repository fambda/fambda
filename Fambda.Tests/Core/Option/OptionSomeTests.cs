using System;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class OptionSomeTests
    {
        [Fact]
        public void Constructor_NotNullValue_Succeeds()
        {
            // Arrange
            var value = "value";

            // Act
            Action ctor = () => _ = new OptionSome<string>(value);

            // Assert
            ctor.Should().NotThrow();
        }

        [Fact]
        public void Constructor_SetsCorrectValue()
        {
            // Arrange
            var value = "value";

            // Act
            var result = new OptionSome<string>(value);

            // Assert
            result.Value.Should().Be(value);
        }

        [Fact]
        public void GetHashCode_SameValues_ReturnSameHash()
        {
            // Arrange
            var optionSomeA = new OptionSome<string>("value");
            var optionSomeB = new OptionSome<string>("value");

            // Act
            var result = optionSomeA.GetHashCode();

            // Assert
            result.Should().Be(optionSomeB.GetHashCode());
        }

        [Fact]
        public void GetHashCode_DifferentValues_ReturnDifferentHash()
        {
            // Arrange
            var optionSomeA = new OptionSome<string>("valueA");
            var optionSomeB = new OptionSome<string>("valueB");

            // Act
            var result = optionSomeA.GetHashCode();

            // Assert
            result.Should().NotBe(optionSomeB.GetHashCode());
        }

        [Fact]
        public void ToString_ReturnsExpectedRepresentation()
        {
            // Arrange
            var value = "value";
            var expectedResult = $"Some({value})";
            var optionSome = new OptionSome<string>(value);

            // Act
            var result = optionSome.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
