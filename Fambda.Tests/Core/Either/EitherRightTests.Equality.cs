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
            var eitherRight = new EitherRight<string>(value);

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
            var first = new EitherRight<string>(value);
            var second = new EitherRight<string>(value);

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
            var first = new EitherRight<string>(valueA);
            var second = new EitherRight<string>(valueB);

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }
    }
}
