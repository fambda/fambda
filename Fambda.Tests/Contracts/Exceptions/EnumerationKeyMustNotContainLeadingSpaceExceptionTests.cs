using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Contracts.Exceptions
{
    [TestClass]
    public class EnumerationKeyMustNotContainLeadingSpaceExceptionTests
    {
        [TestMethod]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new EnumerationKeyMustNotContainLeadingSpaceException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [TestMethod]
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
