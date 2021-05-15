using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Contracts.Exceptions
{
    [TestClass]
    public class EnumerationKeyMustNotBeWhiteSpaceExceptionTests
    {
        [TestMethod]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new EnumerationKeyMustNotBeWhiteSpaceException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [TestMethod]
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
