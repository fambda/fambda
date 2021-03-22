using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Contracts
{
    [TestClass]
    public class ErrorTests
    {
        [TestMethod]
        public void GuardExceptionMustNotBeNullReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(GuardExceptionMustNotBeNullException);

            // Act
            var exception = Error.GuardExceptionMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [TestMethod]
        public void OptionSomeValueMustNotBeNullReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(OptionSomeValueMustNotBeNullException);

            // Act
            var exception = Error.OptionSomeValueMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }
    }
}