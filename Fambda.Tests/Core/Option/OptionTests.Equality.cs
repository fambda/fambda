using Fambda.Tests.Helpers;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda.Tests
{
    public partial class OptionTests
    {
        [Fact]
        public void EqualsOptionSomeShouldReturnTrue()
        {
            // Arrange
            OptionSome<int> optionSome = new OptionSome<int>(1);
            Option<int> option = Some(1);

            // Act
            var result = option.Equals(optionSome);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void EqualsOptionSomeShouldReturnFalse()
        {
            // Arrange
            OptionSome<int> optionSome = new OptionSome<int>(2);
            Option<int> option = Some(1);

            // Act
            var result = option.Equals(optionSome);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void EqualsOptionNoneShouldReturnTrue()
        {
            // Arrange
            OptionNone optionNone = OptionNone.Default;
            Option<int> option = None;

            // Act
            var result = option.Equals(optionNone);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void EqualsOptionNoneShouldReturnFalse()
        {
            // Arrange
            OptionNone optionNone = OptionNone.Default;
            Option<int> option = Some(1);

            // Act
            var result = option.Equals(optionNone);

            // Assert
            result.Should().BeFalse();
        }
    }
}
