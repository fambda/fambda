using Fambda.Tests.Helpers;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda.Tests
{
    public partial class OptionTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void EquableNullMustPass()
        {
            // Arrange
            Option<int> option = Some(1);

            // Act
            var result = new Equable().Null(option);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void EquableEqualMustPassWhenNone()
        {
            // Arrange
            Option<int> first = None;
            Option<int> second = None;

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void EquableEqualMustPassWhenSome()
        {
            // Arrange
            Option<int> first = Some(1);
            Option<int> second = Some(1);

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void EquableUnequalMustPassWhenSome()
        {
            // Arrange
            Option<int> first = Some(1);
            Option<int> second = Some(2);

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void EquableUnequalMustPassWhenNoneAndSome()
        {
            // Arrange
            Option<int> first = None;
            Option<int> second = Some(1);

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }
    }
}
