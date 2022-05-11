using Fambda.DataTypes;
using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class ExceptionalTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void EquableNull_WhenException_Succeeds()
        {
            // Arrange
            var exception = new SomeException();
            Exceptional<string> exceptional = exception;

            // Act
            var result = new Equable().Null(exceptional);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void EquableNull_WhenSuccess_Succeeds()
        {
            // Arrange
            var value = "any value of any type besides Exception";
            Exceptional<string> exceptional = value;

            // Act
            var result = new Equable().Null(exceptional);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void EquableEqual_WhenBothException_Succeeds()
        {
            // Arrange
            var firstException = new SomeException();
            Exceptional<string> first = firstException;

            var secondException = new SomeException();
            Exceptional<string> second = secondException;

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void EquableEqual_WhenBothSuccess_Succeeds()
        {
            // Arrange
            var firstValue = "any value of any type besides Exception";
            Exceptional<string> first = firstValue;

            var secondValue = "any value of any type besides Exception";
            Exceptional<string> second = secondValue;

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void EquableUnequal_WhenFirstExceptionAndSecondSuccess_Succeeds()
        {
            // Arrange
            var firstException = new SomeException();
            Exceptional<string> first = firstException;

            var value = "any value of any type besides Exception";
            Exceptional<string> second = value;

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void EquableUnequal_WhenFirstSuccessAndSecondException_Succeeds()
        {
            // Arrange
            var value = "any value of any type besides Exception";
            Exceptional<string> first = value;

            var secondException = new SomeException();
            Exceptional<string> second = secondException;

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }
    }
}
