using FluentAssertions;
using Xunit;

namespace Fambda.Contracts
{
    public class ErrorTests
    {
        [Fact]
        public void ExceptionalExceptionMustNotBeNull_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(ExceptionalExceptionMustNotBeNullException);

            // Act
            var exception = Error.ExceptionalExceptionMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }
    }
}
