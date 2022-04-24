using Fambda.Helpers;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public partial class OptionTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void EquableNull_OptionInNoneState_Succeeds()
        {
            // Arrange
            Option<int> option = None;

            // Act
            var result = new Equable().Null(option);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void EquableNull_OptionInSomeState_Succeeds()
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
        public void EquableEqual_OptionsInNoneAndNoneStates_Succeeds()
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
        public void EquableEqual_OptionInSomeAndSomeStates_Succeeds()
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
        public void EquableUnequal_OptionsInSomeAndSomeStates_Succeeds()
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
        public void EquableUnequal_OptionsInNoneAndSomeStates_Succeeds()
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
