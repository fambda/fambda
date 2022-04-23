using Fambda.Helpers;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public partial class OptionTests
    {
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
        public void Equals_BoxedOptionInNoneState_ReturnsTrue()
        {
            // Arrange
            Option<int> optionA = new OptionNone();
            Option<int> optionB = new OptionNone();
            var boxedOptionB = optionB as object;

            // Act
            var result = optionA.Equals(boxedOptionB);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_BoxedOptionInNoneState_ReturnsFalse()
        {
            // Arrange
            Option<int> optionA = new OptionSome<int>(1);
            Option<int> optionB = new OptionNone();
            var boxedOptionB = optionB as object;

            // Act
            var result = optionA.Equals(boxedOptionB);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_BoxedOptionInSomeState_ReturnsTrue()
        {
            // Arrange
            Option<int> optionA = new OptionSome<int>(1);
            Option<int> optionB = new OptionSome<int>(1);
            var boxedOptionB = optionB as object;

            // Act
            var result = optionA.Equals(boxedOptionB);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_BoxedOptionInSomeState_ReturnsFalse()
        {
            // Arrange
            Option<int> optionA = new OptionSome<int>(1);
            Option<int> optionB = new OptionSome<int>(2);
            var boxedOptionB = optionB as object;

            // Act
            var result = optionA.Equals(boxedOptionB);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_BoxedOptionNone_ReturnsFalse()
        {
            // Arrange
            Option<int> option = new OptionSome<int>(1);
            OptionNone optionNone = new OptionNone();
            var boxedOptionNone = optionNone as object;

            // Act
            var result = option.Equals(boxedOptionNone);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_BoxedOptionNone_ReturnsTrue()
        {
            // Arrange
            Option<int> option = new OptionNone();
            OptionNone optionNone = new OptionNone();
            var boxedOptionNone = optionNone as object;

            // Act
            var result = option.Equals(boxedOptionNone);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_BoxedOptionSome_ReturnsFalse()
        {
            // Arrange
            Option<int> option = new OptionSome<int>(1);
            OptionSome<int> optionSome = new OptionSome<int>(2);
            var boxedOptionSome = optionSome as object;

            // Act
            var result = option.Equals(boxedOptionSome);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_BoxedOptionSome_ReturnsTrue()
        {
            // Arrange
            Option<int> option = new OptionSome<int>(1);
            OptionSome<int> optionSome = new OptionSome<int>(1);
            var boxedOptionSome = optionSome as object;

            // Act
            var result = option.Equals(boxedOptionSome);

            // Assert
            result.Should().BeTrue();
        }
    }
}
