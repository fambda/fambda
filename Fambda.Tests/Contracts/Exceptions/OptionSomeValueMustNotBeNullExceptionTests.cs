using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests.Contracts.Exceptions
{
    public class OptionSomeValueMustNotBeNullExceptionTests
    {
        [Fact]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new OptionSomeValueMustNotBeNullException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [Fact]
        public void ShouldHaveOptionSomeValueMustNotBeNullMessage()
        {
            // Arrange
            var expectedExceptionMessage = ExceptionMessage.OptionSomeValueMustNotBeNull;

            // Act
            var exception = new OptionSomeValueMustNotBeNullException();

            // Assert
            exception.Message.Should().Be(expectedExceptionMessage);
        }
    }
}
