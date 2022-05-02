using FluentAssertions;
using Xunit;

namespace Fambda.Contracts
{
    public class ErrorTests
    {
        [Fact]
        public void EachParamMustNotBeNull_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(EachParamMustNotBeNullException);

            // Act
            var exception = Error.EachParamMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }
    }
}
