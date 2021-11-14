using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests.Contracts.Exceptions
{
    public class GuardExceptionMustNotBeNullExceptionTests
    {
        [Fact]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new GuardExceptionMustNotBeNullException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [Fact]
        public void ShouldHaveGuardExceptionMustNotBeNullMessage()
        {
            // Arrange
            var expectedExceptionMessage = ExceptionMessage.GuardExceptionMustNotBeNull;

            // Act
            var exception = new GuardExceptionMustNotBeNullException();

            // Assert
            exception.Message.Should().Be(expectedExceptionMessage);
        }
    }
}
