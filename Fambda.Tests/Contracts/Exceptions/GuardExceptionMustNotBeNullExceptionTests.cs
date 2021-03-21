using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Contracts.Exceptions
{
    [TestClass]
    public class GuardExceptionMustNotBeNullExceptionTests
    {
        [TestMethod]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new GuardExceptionMustNotBeNullException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [TestMethod]
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
