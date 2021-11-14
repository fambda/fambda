using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests.Contracts.Exceptions
{
    public class EnumerationKeyMustNotContainLeadingSpaceExceptionTests
    {
        [Fact]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new EnumerationKeyMustNotContainLeadingSpaceException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [Fact]
        public void ShouldHaveEnumerationKeyNotContainLeadingSpaceMessage()
        {
            // Arrange
            var expectedExceptionMessage = ExceptionMessage.EnumerationKeyMustNotContainLeadingSpace;

            // Act
            var exception = new EnumerationKeyMustNotContainLeadingSpaceException();

            // Assert
            exception.Message.Should().Be(expectedExceptionMessage);
        }
    }
}
