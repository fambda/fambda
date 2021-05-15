using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Contracts.Exceptions
{
    [TestClass]
    public class EnumerationKeyMustNotContainTrailingSpaceExceptionTests
    {
        [TestMethod]
        public void ShouldBeAssignableToGuardExceptionType()
        {
            // Arrange
            var guardExceptionType = typeof(GuardException);

            // Act
            var exception = new EnumerationKeyMustNotContainTrailingSpaceException();

            // Assert
            exception.Should().BeAssignableTo(guardExceptionType);
        }

        [TestMethod]
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
