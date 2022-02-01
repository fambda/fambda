using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda.Contracts.Exceptions
{
    public class EnumerationKeyMustNotBeWhiteSpaceExceptionTests
    {
        [Fact]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new EnumerationKeyMustNotBeWhiteSpaceException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [Fact]
        public void ShouldHaveEnumerationKeyNotBeWhiteSpaceMessage()
        {
            // Arrange
            var expectedExceptionMessage = ExceptionMessage.EnumerationKeyMustNotBeWhiteSpace;

            // Act
            var exception = new EnumerationKeyMustNotBeWhiteSpaceException();

            // Assert
            exception.Message.Should().Be(expectedExceptionMessage);
        }
    }
}
