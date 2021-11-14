using System;
using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests
{
    public class OptionSomeTests
    {
        [Fact]
        public void CtorShouldSucceed()
        {
            // Arrange
            var value = "value";

            // Act
            Action ctor = () => new OptionSome<string>(value);

            // Assert
            ctor.Should().NotThrow();
        }

        [Fact]
        public void CtorShouldFail()
        {
            // Arrange
            string value = null;

            // Act
            Action ctor = () => new OptionSome<string>(value);

            // Assert
            ctor.Should().Throw<OptionSomeValueMustNotBeNullException>();
        }

        [Fact]
        public void CtorShouldSetCorrectValue()
        {
            // Arrange
            var value = "value";

            // Act
            var result = new OptionSome<string>(value);

            // Assert
            result.Value.Should().Be(value);
        }

        [Fact]
        public void EqualsObjectShouldReturnTrue()
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
        public void EqualsObjectShouldReturnFalse()
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
        public void EqualsOptionSomeShouldReturnTrue()
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
        public void EqualsOptionSomeShouldReturnFalse()
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
        public void ToStringShouldProvideExpectedRepresentation()
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
