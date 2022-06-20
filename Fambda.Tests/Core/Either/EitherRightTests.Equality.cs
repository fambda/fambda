using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class EitherRightTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Null_DoesPass()
        {
            // Arrange
            var value = "value";
            var eitherRight = F.Right<string>(value);

            // Act
            var result = new Equable().Null(eitherRight);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Equal_DoesPass()
        {
            // Arrange
            var value = "value";
            var first = F.Right<string>(value);
            var second = F.Right<string>(value);

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Unequal_DoesPass()
        {
            // Arrange
            var valueA = "valueA";
            var valueB = "valueB";
            var first = F.Right<string>(valueA);
            var second = F.Right<string>(valueB);

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }
    }
}
