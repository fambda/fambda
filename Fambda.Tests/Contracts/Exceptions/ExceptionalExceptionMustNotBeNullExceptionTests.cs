using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Contracts.Exceptions
{
    [TestClass]
    public class ExceptionalExceptionMustNotBeNullExceptionTests
    {
        [TestMethod]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new ExceptionalExceptionMustNotBeNullException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [TestMethod]
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
