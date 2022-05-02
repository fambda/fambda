using FluentAssertions;
using Xunit;

namespace Fambda.Contracts
{
    public class ErrorTests
    {
        [Fact]
        public void GuardExceptionMustNotBeNull_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(GuardExceptionMustNotBeNullException);

            // Act
            var exception = Error.GuardExceptionMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void OptionSomeValueMustNotBeNull_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(OptionSomeValueMustNotBeNullException);

            // Act
            var exception = Error.OptionSomeValueMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void OptionValueMustNotBeNull_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(OptionValueMustNotBeNullException);

            // Act
            var exception = Error.OptionValueMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void ExceptionalExceptionMustNotBeNull_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(ExceptionalExceptionMustNotBeNullException);

            // Act
            var exception = Error.ExceptionalExceptionMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }
    }
}
