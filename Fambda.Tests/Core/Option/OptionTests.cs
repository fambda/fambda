using System;
using Fambda.Helpers;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public partial class OptionTests
    {
        #region Option

        [Fact]
        public void GetHashCode_OptionsInNoneState_ReturnSameHash()
        {
            // Arrange
            Option<int> optionA = new OptionNone();
            Option<int> optionB = new OptionNone();

            // Act
            var result = optionA.GetHashCode();

            // Assert
            result.Should().Be(optionB.GetHashCode());
        }

        [Fact]
        public void GetHashCode_OptionsInSomeStateWithSameValues_ReturnSameHash()
        {
            // Arrange
            Option<int> optionA = F.Some<int>(1);
            Option<int> optionB = F.Some<int>(1);

            // Act
            var result = optionA.GetHashCode();

            // Assert
            result.Should().Be(optionB.GetHashCode());
        }

        [Fact]
        public void GetHashCode_OptionsInSomeStateWithDifferentValues_ReturnDifferentHash()
        {
            // Arrange
            Option<int> optionA = F.Some<int>(1);
            Option<int> optionB = F.Some<int>(2);

            // Act
            var result = optionA.GetHashCode();

            // Assert
            result.Should().NotBe(optionB.GetHashCode());
        }

        [Fact]
        public void GetHashCode_OptionsInDifferentState_ReturnDifferentHash()
        {
            // Arrange
            Option<int> optionA = new OptionNone();
            Option<int> optionB = F.Some<int>(1);

            // Act
            var result = optionA.GetHashCode();

            // Assert
            result.Should().NotBe(optionB.GetHashCode());
        }

        [Fact]
        public void ImplicitConversion_OptionSomeToOption_ReturnsOptionInSomeState()
        {
            // Arrange
            var value = "value";
            var optionSome = F.Some<string>(value);

            // Act
            Option<string> option = optionSome;
            var result = option.IsSome;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ImplicitConversion_OptionNoneToOption_ReturnsOptionInNoneState()
        {
            // Arrange
            var optionNone = new OptionNone();

            // Act
            Option<string> option = optionNone;
            var result = option.IsNone;

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("value", "Some(value)")]
        [InlineData(null, "None")]
        public void ImplicitConvertion_ValueToOption_Succeeds(string input, string expected)
        {
            // Arrange
            var value = input;

            // Act
            Option<string> option = value;
            var result = option.ToString();

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void IsNone_ReturnsTrue()
        {
            // Arrange
            Option<int> option = new OptionNone();

            // Act
            var result = option.IsNone;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsNone_ReturnsFalse()
        {
            // Arrange
            Option<int> option = F.Some<int>(1);

            // Act
            var result = option.IsNone;

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsSome_ReturnsTrue()
        {
            // Arrange
            Option<int> option = F.Some<int>(1);

            // Act
            var result = option.IsSome;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsSome_ReturnsFalse()
        {
            // Arrange
            Option<int> option = new OptionNone();

            // Act
            var result = option.IsSome;

            // Assert
            result.Should().BeFalse();
        }

        #endregion

        #region Match

        [Fact]
        public void Match_ReturnsSomeResult()
        {
            // Arrange
            Option<int> option = Some(1);

            // Act
            var result = option.Match(
                                    None: () => "Result=None",
                                    Some: (i) => $"Result=Some({i})"
                                );

            // Assert
            result.Should().Be("Result=Some(1)");
        }

        [Fact]
        public void Match_ReturnsNoneResult()
        {
            // Arrange
            Option<int> option = None;

            // Act
            var result = option.Match(
                                    None: () => "Result=None",
                                    Some: (i) => $"Result=Some({i})"
                                );

            // Assert
            result.Should().Be("Result=None");
        }

        [Fact]
        public void Match_ThroughSome_ReturnsNull()
        {
            // Arrange
            Option<int> option = Some(1);
            Func<int, string?> some = (int x) => null;
            Func<string?> none = () => null;

            // Act
            var result = option.Match(
                                  None: none,
                                  Some: some
                                );

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void Match_ThroughNone_ReturnsNull()
        {
            // Arrange
            Option<int> option = None;
            Func<int, string> some = (i) => $"Result=Some({i})";
            Func<string?> none = () => null;

            // Act
            var result = option.Match(
                                  None: none,
                                  Some: some
                                );

            // Assert
            result.Should().BeNull();
        }

        #endregion
    }
}
