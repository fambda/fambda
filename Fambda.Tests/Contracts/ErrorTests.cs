using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda.Contracts
{
    public class ErrorTests
    {
        [Fact]
        public void GuardExceptionMustNotBeNullReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(GuardExceptionMustNotBeNullException);

            // Act
            var exception = Error.GuardExceptionMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void OptionSomeValueMustNotBeNullReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(OptionSomeValueMustNotBeNullException);

            // Act
            var exception = Error.OptionSomeValueMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void OptionValueMustNotBeNullReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(OptionValueMustNotBeNullException);

            // Act
            var exception = Error.OptionValueMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void ExceptionalExceptionMustNotBeNullReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(ExceptionalExceptionMustNotBeNullException);

            // Act
            var exception = Error.ExceptionalExceptionMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void EnumerationKeyMustNotBeNullReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(EnumerationKeyMustNotBeNullException);

            // Act
            var exception = Error.EnumerationKeyMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void EnumerationKeyMustNotBeEmptyReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(EnumerationKeyMustNotBeEmptyException);

            // Act
            var exception = Error.EnumerationKeyMustNotBeEmpty();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void EnumerationKeyMustNotBeWhiteSpaceReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(EnumerationKeyMustNotBeWhiteSpaceException);

            // Act
            var exception = Error.EnumerationKeyMustNotBeWhiteSpace();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void EnumerationKeyMustNotContainLeadingSpaceReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(EnumerationKeyMustNotContainLeadingSpaceException);

            // Act
            var exception = Error.EnumerationKeyMustNotContainLeadingSpace();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void EnumerationKeyMustNotContainTrailingSpaceReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(EnumerationKeyMustNotContainTrailingSpaceException);

            // Act
            var exception = Error.EnumerationKeyMustNotContainTrailingSpace();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }
    }
}
