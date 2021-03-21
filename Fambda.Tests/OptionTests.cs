using System;
using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
