using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class OptionSomeTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Null_DoesPass()
        {
            // Arrange
            var value = "value";
            var optionSome = new OptionSome<string>(value);

            // Act
            var result = new Equable().Null(optionSome);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Equal_DoesPass()
        {
            // Arrange
            var value = "value";
            var first = new OptionSome<string>(value);
            var second = new OptionSome<string>(value);

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
            var first = new OptionSome<string>(valueA);
            var second = new OptionSome<string>(valueB);

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }
    }
}
