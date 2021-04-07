using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class OptionTests
    {
        #region Option

        [TestMethod]
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

        [TestMethod]
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

        [DataTestMethod]
        [DataRow("value", "Some(value)")]
        [DataRow(null, "None")]
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

        #region Equals

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        #endregion

        #region Match

        [TestMethod]
        public void MatchShouldSucceedWhenSome()
        {
            // Arrange
            Option<int> option = Some(1);

            // Act
            var result = option.Match(
                                    Some: (i) => $"Result=Some({i})",
                                    None: () => "Result=None"
                                );

            // Assert
            result.Should().Be("Result=Some(1)");
        }

        [TestMethod]
        public void MatchShouldSucceedWhenNone()
        {
            // Arrange
            Option<int> option = None;

            // Act
            var result = option.Match(
                                    Some: (i) => $"Result=Some({i})",
                                    None: () => "Result=None"
                                );

            // Assert
            result.Should().Be("Result=None");
        }

        #endregion
    }
}
