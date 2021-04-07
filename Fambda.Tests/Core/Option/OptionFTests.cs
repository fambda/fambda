using System;
using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class OptionFTests
    {
        [TestMethod]
        public void SomeShouldSucceed()
        {
            // Arrange
            var value = "value";

            // Act
            Option<string> option = Some(value);

            // Assert
            option.ToString().Should().Be("Some(value)");
        }

        [TestMethod]
        public void SomeShouldFail()
        {
            // Arrange
            string value = null;

            // Act
            Action act = () => { Option<string> option = Some(value); };

            // Assert
            act.Should().Throw<OptionSomeValueMustNotBeNullException>();
        }

        [TestMethod]
        public void NoneShouldSucceed()
        {
            // Arrange
            var none = None;

            // Act
            Option<string> option = none;

            // Assert
            option.ToString().Should().Be("None");
        }
    }
}
