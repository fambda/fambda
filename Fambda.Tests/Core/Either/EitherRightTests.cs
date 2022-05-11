using System;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public class EitherRightTests
    {
        [Fact]
        public void Constructor_Succeeds()
        {
            // Arrange
            var value = "right";

            // Act
            Action ctor = () => { _ = new EitherRight<string>(value); };

            // Assert
            ctor.Should().NotThrow();
        }

        [Fact]
        public void Constructor_SetsCorrectValue()
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
        public void EqualsObject_WhenBothValueSameNotNull_ReturnsTrue()
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
        public void EqualsObject_WhenSameTypeAndDifferentValues_ReturnsFalse()
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
        public void EqualsObject_WhenDifferentTypes_ReturnsFalse()
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
        public void Equals_EitherRight_ReturnsTrue()
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
        public void Equals_EitherRight_ReturnsFalse()
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
        public void ToString_ReturnsExpectedRepresentation()
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
