using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class EitherLeftTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Null_DoesPass()
        {
            // Arrange
            var value = "value";
            var eitherLeft = new EitherLeft<string>(value);

            // Act
            var result = new Equable().Null(eitherLeft);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Equal_DoesPass()
        {
            // Arrange
            var value = "value";
            var first = new EitherLeft<string>(value);
            var second = new EitherLeft<string>(value);

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
            var first = new EitherLeft<string>(valueA);
            var second = new EitherLeft<string>(valueB);

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }
    }
}
