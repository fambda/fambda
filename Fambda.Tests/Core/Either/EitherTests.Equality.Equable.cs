using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class EitherTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void EquableNull_WhenLeft_Succeeds()
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
        public void EquableNull_WhenRight_Succeeds()
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
        public void EquableEqual_WhenBothLeft_Succeeds()
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
        public void EquableEqual_WhenBothRight_Succeeds()
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
        public void EquableUnequal_WhenFirstLeftAndSecondRight_Succeeds()
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
        public void EquableUnequal_WhenFirstRightAndSecondLeft_Succeeds()
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
