using System;
using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public class OptionSomeTests
    {
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

        public void OptionSomeEqualsObjectShouldReturnTrue()
        {
            // Arrange
            var first = new OptionSome<string>("value");
            var second = new OptionSome<string>("value");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
        }

        public void OptionSomeEqualsObjectShouldReturnFalse()
        {
            // Arrange
            var first = new OptionSome<string>("value1");
            var second = new OptionSome<string>("value2");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void OptionSomeEqualsOptionSomeShouldReturnTrue()
        {
            // Arrange
            var first = new OptionSome<string>("value");
            var second = new OptionSome<string>("value");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void OptionSomeEqualsOptionSomeShouldReturnFalse()
        {
            // Arrange
            var first = new OptionSome<string>("value1");
            var second = new OptionSome<string>("value2");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
        }
    }
}
