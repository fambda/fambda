using System;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class EitherLeftTests
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
