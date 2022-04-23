using System;
using Fambda.Contracts;
using Fambda.Helpers;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public partial class OptionTests
    {
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
            Option<int> optionA = new OptionSome<int>(1);
            Option<int> optionB = new OptionSome<int>(1);

            // Act
            var result = optionA.GetHashCode();

            // Assert
            result.Should().Be(optionB.GetHashCode());
        }

        [Fact]
        public void GetHashCode_OptionsInSomeStateWithDifferentValues_ReturnDifferentHash()
        {
            // Arrange
            Option<int> optionA = new OptionSome<int>(1);
            Option<int> optionB = new OptionSome<int>(2);

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
            Option<int> optionB = new OptionSome<int>(1);

            // Act
            var result = optionA.GetHashCode();
            var t = optionB.GetHashCode();

            // Assert
            result.Should().NotBe(optionB.GetHashCode());
        }

        #region Option

        [Fact]
        public void ImplicitOperatorOverloadingShouldSucceedWithOptionSome()
        {
            // Arrange
            var value = "value";
            var optionSome = new OptionSome<string>(value);

            // Act
            Option<string> option = optionSome;
            var result = option.ToString();

            // Assert
            result.Should().Be("Some(value)");
        }

        [Fact]
        public void ImplicitOperatorOverloadingShouldSucceedWithOptionNone()
        {
            // Arrange
            var optionNone = new OptionNone();

            // Act
            Option<string> option = optionNone;
            var result = option.ToString();

            // Assert
            result.Should().Be("None");
        }

        [Theory]
        [InlineData("value", "Some(value)")]
        [InlineData(null, "None")]
        public void ImplicitOperatorOverloadingShouldSucceedWithValue(string input, string expected)
        {
            // Arrange
            var value = input;

            // Act
            Option<string> option = value;
            var result = option.ToString();

            // Assert
            result.Should().Be(expected);
        }

        #endregion

        #region Match

        [Fact]
        public void MatchShouldSucceedWhenSome()
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
        public void MatchShouldSucceedWhenNone()
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
        public void MatchShouldFailWhenReturnValueIsNullThroughSome()
        {
            // Arrange
            Option<int> option = Some(1);
            Func<int, string> some = (int x) => (string)null;
            Func<string> none = () => null;

            // Act
            Action act = () =>
            {
                option.Match(
                            None: none,
                            Some: some
                        );
            };

            // Assert
            act.Should().Throw<OptionMatchReturnMustNotBeNullException>();
        }

        [Fact]
        public void MatchShouldFailWhenReturnValueIsNullThroughNone()
        {
            // Arrange
            Option<int> option = None;
            Func<int, string> some = (i) => $"Result=Some({i})";
            Func<string> none = () => null;

            // Act
            Action act = () =>
            {
                option.Match(
                    None: none,
                    Some: some
                );
            };

            // Assert
            act.Should().Throw<OptionMatchReturnMustNotBeNullException>();
        }

        #endregion
    }
}
