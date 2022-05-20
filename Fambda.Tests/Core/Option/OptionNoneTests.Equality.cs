using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class OptionNoneTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Null_DoesPass()
        {
            // Arrange
            var optionNone = new OptionNone();

            // Act
            var result = new Equable().Null(optionNone);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Equal_DoesPass()
        {
            // Arrange
            var first = new OptionNone();
            var second = new OptionNone();

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Unequal_DoesNotPass()
        {
            // Arrange
            var first = new OptionNone();
            var second = new OptionNone();

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().NotPass();
        }
    }
}
