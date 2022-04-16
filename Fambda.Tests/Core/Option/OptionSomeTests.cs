using System;
using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public class OptionSomeTests
    {
        [Fact]
        public void Constructor_NotNullValue_Succeeds()
        {
            // Arrange
            var value = "value";

            // Act
            Action ctor = () => new OptionSome<string>(value);

            // Assert
            ctor.Should().NotThrow();
        }

        [Fact]
        public void Constructor_NullValue_ThrowsOptionSomeValueMustNotBeNullException()
        {
            // Arrange
            string value = null;

            // Act
            Action ctor = () => new OptionSome<string>(value);

            // Assert
            ctor.Should().Throw<OptionSomeValueMustNotBeNullException>();
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
        public void GetHashCode_ReturnsSameHashForSameValue()
        {
            // Arrange
            var first = new OptionSome<string>("value");
            var second = new OptionSome<string>("value");

            // Act
            var result = first.GetHashCode();

            // Assert
            result.Should().Be(second.GetHashCode());
        }

        [Fact]
        public void Equals_Object_ReturnsTrue()
        {
            // Arrange
            var first = new OptionSome<string>("value");
            var second = new OptionSome<string>("value");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_Object_ReturnsFalse()
        {
            // Arrange
            var first = new OptionSome<string>("value1");
            var second = new OptionSome<string>("value2");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_OptionSome_ReturnsTrue()
        {
            // Arrange
            var first = new OptionSome<string>("value");
            var second = new OptionSome<string>("value");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_OptionSome_ReturnsFalse()
        {
            // Arrange
            var first = new OptionSome<string>("value1");
            var second = new OptionSome<string>("value2");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
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
