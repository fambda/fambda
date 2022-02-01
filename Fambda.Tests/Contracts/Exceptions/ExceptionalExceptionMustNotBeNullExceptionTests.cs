using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda.Contracts.Exceptions
{
    public class ExceptionalExceptionMustNotBeNullExceptionTests
    {
        [Fact]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new ExceptionalExceptionMustNotBeNullException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [Fact]
        public void ShouldHaveExceptionalExeptionMustNotBeNullMessage()
        {
            // Arrange
            var expectedExceptionMessage = ExceptionMessage.ExceptionalExceptionMustNotBeNull;

            // Act
            var exception = new ExceptionalExceptionMustNotBeNullException();

            // Assert
            exception.Message.Should().Be(expectedExceptionMessage);
        }
    }
}
