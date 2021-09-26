using System;
using Fambda.Contracts;
using Fambda.Tests.DataTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public partial class ExceptionalTests
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
        public void ImplicitOperatorOverloadingShouldThrowWhenExceptionIsNull()
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

        [TestMethod]
        public void ImplicitOperatorOverloadingShouldSetCorrectDataWhenExceptionIsNotNull()
        {
            // Arrange
            var exception = new SomeException();

            // Act
            Exceptional<string> exceptional = exception;

            // Assert
            exceptional.Exception.Should().Be(exception);
            exceptional.Value.Should().BeNull();
        }

        [TestMethod]
        public void ImplicitOperatorOverloadingShouldSetCorrectDataWhenNotAnExceptionIsPassed()
        {
            // Arrange
            var value = "any value of any type besides Exception";

            // Act
            Exceptional<string> exceptional = value;

            // Assert
            exceptional.Exception.Should().BeNull();
            exceptional.Value.Should().Be(value);
        }

        #endregion

        #region Match

        [TestMethod]
        public void MatchShouldReturnException()
        {
            // Arrange
            var exception = new SomeException();
            Exceptional<string> exceptional = exception;

            // Act
            var result = exceptional.Match(
                                    Exception: (x) => $"Result=Exception({x.GetType().Name})",
                                    Success: (x) => $"Result=Success({x})"
                                );

            // Assert
            result.Should().Be("Result=Exception(SomeException)");
        }

        [TestMethod]
        public void MatchShouldReturnSuccess()
        {
            // Arrange
            var value = "value";
            Exceptional<string> exceptional = value;

            // Act
            var result = exceptional.Match(
                                    Exception: (x) => $"Result=Exception({x.GetType().Name})",
                                    Success: (x) => $"Result=Success({x})"
                                );

            // Assert
            result.Should().Be("Result=Success(value)");
        }

        #endregion

    }
}
