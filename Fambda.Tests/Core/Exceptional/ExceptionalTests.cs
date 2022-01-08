using System;
using System.Threading.Tasks;
using Fambda.Contracts;
using Fambda.Tests.DataTypes;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests
{
    public partial class ExceptionalTests
    {
        #region Exceptional

        [Fact]
        public void ImplicitOperatorOverloadingShouldNotThrowWhenExceptionIsNotNull()
        {
            // Arrange
            var exception = new SomeException();

            // Act
            Action act = () => { Exceptional<string> exceptional = exception; };

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void ImplicitOperatorOverloadingShouldThrowWhenExceptionIsNull()
        {
            // Arrange
            SomeException exception = null;

            // Act
            Action act = () => { Exceptional<string> exceptional = exception; };

            // Assert
            act.Should().Throw<ExceptionalExceptionMustNotBeNullException>();
        }

        [Fact]
        public void ImplicitOperatorOverloadingShouldNotThrowWhenNotAnExceptionIsPassed()
        {
            // Arrange
            var value = "any value of any type besides Exception";

            // Act
            Action act = () => { Exceptional<string> exceptional = value; };

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
        public async Task MatchWithTaskShouldReturnException()
        {
            // Arrange
            var exception = new SomeException("message");
            Exceptional<string> exceptional = exception;

            // Act
            var result = await exceptional.Match(
                                    Exception: (x) => $"Result=Exception({x.GetType().Name})",
                                    Success: async (x) => await Task.FromResult($"Result=Success({x})")
                                );

            // Assert
            result.Should().Be("Result=Exception(SomeException)");
        }

        [Fact]
        public async Task MatchWithTaskShouldReturnSuccess()
        {
            // Arrange
            var value = "value";
            Exceptional<string> exceptional = value;

            // Act
            var result = await exceptional.Match(
                                    Exception: (x) => $"Result=Exception({x.GetType().Name})",
                                    Success: async (x) => await Task.FromResult($"Result=Success({x})")
                                );

            // Assert
            result.Should().Be("Result=Success(value)");
        }

        #endregion
    }
}
