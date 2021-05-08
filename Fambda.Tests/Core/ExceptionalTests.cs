using System;
using Fambda.Contracts;
using Fambda.Tests.DataTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public class ExceptionalTests
    {
        #region Exceptional

        [TestMethod]
        public void ImplicitOperatorOverloadingShouldNotThrowWhenExceptionIsNotNull()
        {
            // Arrange
            var exception = new SomeException();

            // Act
            Action act = () => { Exceptional<string> exceptional = exception; };

            // Assert
            act.Should().NotThrow();
        }

        [TestMethod]
        public void ImplicitOperatorOverloadingShouldThrowWhenExceptionIsNotNull()
        {
            // Arrange
            SomeException exception = null;

            // Act
            Action act = () => { Exceptional<string> exceptional = exception; };

            // Assert
            act.Should().Throw<ExceptionalExceptionMustNotBeNullException>();
        }

        [TestMethod]
        public void ImplicitOperatorOverloadingShouldNotThrowWhenNotAnExceptionIsPassed()
        {
            // Arrange
            var value = "any value of any type besides Exception";

            // Act
            Action act = () => { Exceptional<string> exceptional = value; };

            // Assert
            act.Should().NotThrow();
        }

        #endregion
    }
}
