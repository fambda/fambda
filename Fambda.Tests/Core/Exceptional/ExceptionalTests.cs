using System;
using System.Threading.Tasks;
using Fambda.DataTypes;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class ExceptionalTests
    {
        #region Exceptional

        [Fact]
        public void ImplicitConversion_ExceptionToExceptional_DoesNotThrow()
        {
            // Arrange
            var exception = new SomeException();

            // Act
            Action act = () => { Exceptional<string> exceptional = exception; };

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void ImplicitConversion_NotExceptionValueToExceptional_DoesNotThrow()
        {
            // Arrange
            var value = "any value of any type besides Exception";

            // Act
            Action act = () => { Exceptional<string> exceptional = value; };

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void ImplicitConversion_ExceptionToExceptional_SetsCorrectData()
        {
            // Arrange
            var exception = new SomeException();

            // Act
            Exceptional<string> exceptional = exception;

            // Assert
            exceptional.ToString().Should().Be($"Exception({exception.Message})");
        }

        [Fact]
        public void ImplicitConversion_NotExceptionValueToExceptional_SetsCorrectData()
        {
            // Arrange
            var value = "any value of any type besides Exception";

            // Act
            Exceptional<string> exceptional = value;

            // Assert
            exceptional.ToString().Should().Be($"Success({value})");
        }

        #endregion

        #region Match

        [Fact]
        public void Match_ReturnsExceptionResult()
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
        public void Match_ReturnsSuccessResult()
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
        public async Task Match_WithTask_ReturnsException()
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
        public async Task Match_WithTask_ReturnsSuccess()
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
