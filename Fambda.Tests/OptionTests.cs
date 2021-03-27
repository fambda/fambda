using System;
using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class OptionTests
    {
        #region OptionNone

        [TestMethod]
        public void OptionNoneShouldEqualWithDefault()
        {
            // Arrange
            var first = new OptionNone();
            var second = default(OptionNone);


            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
        }

        #endregion

        #region OptionSome

        [TestMethod]
        public void OptionSomeCreateShouldSucceed()
        {
            // Arrange
            var value = "value";

            // Act
            Action ctor = () => new OptionSome<string>(value);

            // Assert
            ctor.Should().NotThrow();
        }

        [TestMethod]
        public void OptionSomeCreateShouldFail()
        {
            // Arrange
            string value = null;

            // Act
            Action ctor = () => new OptionSome<string>(value);

            // Assert
            ctor.Should().Throw<OptionSomeValueMustNotBeNullException>();
        }

        [TestMethod]
        public void OptionSomeShouldHaveExpectedValue()
        {
            // Arrange
            var value = "value";

            // Act
            var result = new OptionSome<string>(value);

            // Assert
            result.Value.Should().Be(value);
        }

        #endregion

        #region Option

        [TestMethod]
        public void OptionCtorThroughImplicitOperatorOverloadingShouldSucceedWithOptionSome()
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
        public void OptionCtorThroughImplicitOperatorOverloadingShouldSucceedWithOptionNone()
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
        public void OptionCtorThroughImplicitOperatorOverloadingShouldSucceedWithValue(string input, string expected)
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

        #region OptionMatch

        [TestMethod]
        public void OptionMatchShouldSucceedWhenSome()
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
        public void OptionMatchShouldSucceedWhenNone()
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

        #region Option.F

        [TestMethod]
        public void FSomeShouldSucceed()
        {
            // Arrange
            var value = "value";

            // Act
            Option<string> option = Some(value);

            // Assert
            option.ToString().Should().Be("Some(value)");
        }

        [TestMethod]
        public void FSomeShouldFail()
        {
            // Arrange
            string value = null;

            // Act
            Action act = () => { Option<string> option = Some(value); };

            // Assert
            act.Should().Throw<OptionSomeValueMustNotBeNullException>();
        }

        [TestMethod]
        public void FNoneShouldSucceed()
        {
            // Arrange
            var none = None;

            // Act
            Option<string> option = none;

            // Assert
            option.ToString().Should().Be("None");
        }

        #endregion

        #region OptionExt

        #region Map

        [TestMethod]
        public void OptionMapShouldSucceedWhenSome()
        {
            // Arrange
            var value = 1;
            Option<int> option = Some(value);
            Func<int, string> toString = i => i.ToString();

            // Act
            var result = option.Map(toString);

            // Assert
            option.ToString().Should().Be("Some(1)");
        }

        [TestMethod]
        public void OptionMapShouldSucceedWhenNone()
        {
            // Arrange
            Option<int> option = None;
            Func<int, string> toString = i => i.ToString();

            // Act
            var result = option.Map(toString);

            // Assert
            option.ToString().Should().Be("None");
        }

        #endregion



        #endregion
    }
}
