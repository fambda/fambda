using System;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class EitherRightTests
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
