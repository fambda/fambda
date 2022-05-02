using System;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public class EitherRightTests
    {
        [Fact]
        public void CtorShouldSucceed()
        {
            // Arrange
            var value = "right";

            // Act
            Action ctor = () => { new EitherRight<string>(value); };

            // Assert
            ctor.Should().NotThrow();
        }

        [Fact]
        public void CtorShouldSetCorrectValue()
        {
            // Arrange
            var value = "right";
            var eitherRight = new EitherRight<string>(value);

            // Act
            var result = eitherRight.Value;

            // Assert
            result.Should().Be(value);
        }

        [Fact]
        public void EqualsObjectShouldReturnTrueWhenBothValueSameNotNull()
        {
            // Arrange
            var first = new EitherRight<string>("value");
            var second = new EitherRight<string>("value");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void EqualsObjectShouldReturnFalseWhenSameTypeAndDifferentValues()
        {
            // Arrange
            var first = new EitherRight<string>("value1");
            var second = new EitherRight<string>("value2");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void EqualsObjectShouldReturnFalseWhenDifferentTypes()
        {
            // Arrange
            var first = new EitherRight<string>("1");
            var second = new EitherRight<int>(1);

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void EqualsEitherLeftShouldReturnTrueWhenBothValueSameNotNull()
        {
            // Arrange
            var first = new EitherRight<string>("value");
            var second = new EitherRight<string>("value");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void EqualsEitherRightShouldReturnFalse()
        {
            // Arrange
            var first = new EitherRight<string>("value1");
            var second = new EitherRight<string>("value2");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ToStringShouldProvideExpectedRepresentation()
        {
            // Arrange
            var value = "right";
            var expectedResult = $"Right({value})";
            var eitherRight = new EitherRight<string>(value);

            // Act
            var result = eitherRight.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
