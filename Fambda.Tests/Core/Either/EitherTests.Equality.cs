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
            Either<string, int> either = F.Left<string>("left");

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
            Either<string, int> either = F.Right<int>(1);

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
            var first = F.Left<string>("left");
            var second = F.Left<string>("left");

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
            var first = F.Right<int>(1);
            var second = F.Right<int>(1);

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
            Either<string, int> first = F.Left<string>("left");
            Either<string, int> second = F.Right<int>(1);

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }
    }
}
