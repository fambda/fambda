using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests.Contracts.Exceptions
{
    public class EnumerationKeyMustNotContainTrailingSpaceExceptionTests
    {
        [Fact]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new EnumerationKeyMustNotContainTrailingSpaceException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [Fact]
        public void ShouldHaveEnumerationKeyMustNotContainTrailingSpaceMessage()
        {
            // Arrange
            var expectedExceptionMessage = ExceptionMessage.EnumerationKeyMustNotContainTrailingSpace;

            // Act
            var exception = new EnumerationKeyMustNotContainTrailingSpaceException();

            // Assert
            exception.Message.Should().Be(expectedExceptionMessage);
        }
    }
}
