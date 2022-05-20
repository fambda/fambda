using Fambda.DataTypes;
using Fambda.Helpers;
using Xunit;

namespace Fambda
{
    public partial class ExceptionalTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_NullWhenInException_DoesPass()
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
        public void Equable_NullWhenInSuccess_DoesPass()
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
        public void Equable_EqualWhenExceptionalInExceptionAndExceptionalInException_DoesPass()
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
        public void Equable_EqualWhenExceptionalInSuccessAndExceptionalInSuccess_DoesPass()
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
        public void Equable_UnequalWhenExceptionalInExceptionAndExceptionalInSuccess_DoesPass()
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
    }
}
