using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests.Contracts.Exceptions
{
    public class EnumerationKeyMustNotBeEmptyExceptionTests
    {
        [Fact]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new EnumerationKeyMustNotBeEmptyException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [Fact]
        public void ShouldHaveEnumerationKeyMustNotBeEmptyMessage()
        {
            // Arrange
            var expectedExceptionMessage = ExceptionMessage.EnumerationKeyMustNotBeEmpty;

            // Act
            var exception = new EnumerationKeyMustNotBeEmptyException();

            // Assert
            exception.Message.Should().Be(expectedExceptionMessage);
        }
    }
}
