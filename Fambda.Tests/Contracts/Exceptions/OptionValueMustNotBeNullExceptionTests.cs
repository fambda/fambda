using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda.Contracts.Exceptions
{
    public class OptionValueMustNotBeNullExceptionTests
    {
        [Fact]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new OptionValueMustNotBeNullException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [Fact]
        public void ShouldHaveOptionValueMustNotBeNullMessage()
        {
            // Arrange
            var expectedExceptionMessage = ExceptionMessage.OptionValueMustNotBeNull;

            // Act
            var exception = new OptionValueMustNotBeNullException();

            // Assert
            exception.Message.Should().Be(expectedExceptionMessage);
        }
    }
}
