using System;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public class EitherLeftTests
    {
        [Fact]
        public void Constructor_Succeeds()
        {
            // Arrange
            var value = "left";

            // Act
            Action ctor = () => { _ = new EitherLeft<string>(value); };

            // Assert
            ctor.Should().NotThrow();
        }

        [Fact]
        public void Constructor_SetsCorrectValue()
        {
            // Arrange
            var value = "left";
            var eitherLeft = new EitherLeft<string>(value);

            // Act
            var result = eitherLeft.Value;

            // Assert
            result.Should().Be(value);
        }

        [Fact]
        public void EqualsObject_WhenBothValueSameNotNull_ReturnsTrue()
        {
            // Arrange
            var first = new EitherLeft<string>("value");
            var second = new EitherLeft<string>("value");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void EqualsObject_WhenSameTypeAndDifferentValues_ReturnsFalse()
        {
            // Arrange
            var first = new EitherLeft<string>("value1");
            var second = new EitherLeft<string>("value2");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void EqualsObject_WhenDifferentTypes_ReturnsFalse()
        {
            // Arrange
            var first = new EitherLeft<string>("1");
            var second = new EitherLeft<int>(1);

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_EitherLeft_ReturnsTrue()
        {
            // Arrange
            var first = new EitherLeft<string>("value");
            var second = new EitherLeft<string>("value");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_EitherLeft_ReturnsFalse()
        {
            // Arrange
            var first = new EitherLeft<string>("value1");
            var second = new EitherLeft<string>("value2");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void ToString_ReturnsExpectedRepresentation()
        {
            // Arrange
            var value = "left";
            var expectedResult = $"Left({value})";
            var eitherLeft = new EitherLeft<string>(value);

            // Act
            var result = eitherLeft.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
