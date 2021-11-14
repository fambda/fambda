using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests.Contracts.Exceptions
{
    public class EnumerationKeyMustNotBeNullExceptionTests
    {
        [Fact]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new EnumerationKeyMustNotBeNullException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [Fact]
        public void ShouldHaveEnumerationKeyMustNotBeNullMessage()
        {
            // Arrange
            var expectedExceptionMessage = ExceptionMessage.EnumerationKeyMustNotBeNull;

            // Act
            var exception = new EnumerationKeyMustNotBeNullException();

            // Assert
            exception.Message.Should().Be(expectedExceptionMessage);
        }
    }
}
