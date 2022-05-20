using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class EitherTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_NullWhenEitherInLeftState_DoesPass()
        {
            // Arrange
            var either = new Either<string, int>("left");

            // Act
            var result = new Equable().Null(either);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_NullWhenEitherInRight_DoesPass()
        {
            // Arrange
            var either = new Either<string, int>(1);

            // Act
            var result = new Equable().Null(either);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_EqualWhenEitherInLeftAndEitherInLeft_DoesPass()
        {
            // Arrange
            var first = new Either<string, int>("left");
            var second = new Either<string, int>("left");

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_EqualWhenEitherInRightAndEitherInRight_DoesPass()
        {
            // Arrange
            var first = new Either<string, int>(1);
            var second = new Either<string, int>(1);

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_UnequalWhenEitherInLeftAndEitherInRight_DoesPass()
        {
            // Arrange
            var first = new Either<string, int>("left");
            var second = new Either<string, int>(1);

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }
    }
}
