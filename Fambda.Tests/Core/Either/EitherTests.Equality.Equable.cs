using Fambda.Tests.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests
{
    public partial class EitherTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void EquableNullMustPassWhenLeft()
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
        public void EquableNullMustPassWhenRight()
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
        public void EquableEqualMustPassWhenBothLeft()
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
        public void EquableEqualMustPassWhenBothRight()
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
        public void EquableUnequalMustPassWhenFirstLeftAndSecondRight()
        {
            // Arrange
            var first = new Either<string, int>("left");
            var second = new Either<string, int>(1);

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void EquableUnequalMustPassWhenFirstRightAndSecondLeft()
        {
            // Arrange
            var first = new Either<string, int>(1);
            var second = new Either<string, int>("left");

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }
    }
}
