using FluentAssertions;
using Xunit;

namespace Fambda.Contracts
{
    public class ErrorTests
    {
        [Fact]
        public void GuardExceptionMustNotBeNull_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(GuardExceptionMustNotBeNullException);

            // Act
            var exception = Error.GuardExceptionMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void OptionSomeValueMustNotBeNull_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(OptionSomeValueMustNotBeNullException);

            // Act
            var exception = Error.OptionSomeValueMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void OptionValueMustNotBeNull_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(OptionValueMustNotBeNullException);

            // Act
            var exception = Error.OptionValueMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

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

        [Fact]
        public void EnumerationKeyMustNotBeNull_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(EnumerationKeyMustNotBeNullException);

            // Act
            var exception = Error.EnumerationKeyMustNotBeNull();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void EnumerationKeyMustNotBeEmpty_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(EnumerationKeyMustNotBeEmptyException);

            // Act
            var exception = Error.EnumerationKeyMustNotBeEmpty();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void EnumerationKeyMustNotBeWhiteSpace_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(EnumerationKeyMustNotBeWhiteSpaceException);

            // Act
            var exception = Error.EnumerationKeyMustNotBeWhiteSpace();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void EnumerationKeyMustNotContainLeadingSpace_ReturnsExpectedException()
        {
            // Arrange
            var expectedExceptionType = typeof(EnumerationKeyMustNotContainLeadingSpaceException);

            // Act
            var exception = Error.EnumerationKeyMustNotContainLeadingSpace();

            // Assert
            exception.Should().BeOfType(expectedExceptionType);
        }

        [Fact]
        public void EnumerationKeyMustNotContainTrailingSpace_ReturnsExpectedException()
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
