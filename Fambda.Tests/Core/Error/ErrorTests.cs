using FluentAssertions;
using Xunit;

namespace Fambda
{
    public class ErrorTests
    {
        [Fact]
        public void New_ReturnsExpectedWithCode()
        {
            // Arrange
            var code = "InvalidInput";

            // Act
            var error = Error.New(code);

            // Assert
            error.Should().BeOfType<Error.Expected>();
            error.Code.Should().Be(code);
            error.Message.Should().BeNull();
        }

        [Fact]
        public void New_ReturnsExpectedWithCodeAndMessage()
        {
            // Arrange
            var code = "InvalidInput";
            var message = "Item has invalid value.";

            // Act
            var error = Error.New(code, message);

            // Assert
            error.Should().BeOfType<Error.Expected>();
            error.Code.Should().Be(code);
            error.Message.Should().Be(message);
        }

        [Fact]
        public void New_ReturnsUnexpected()
        {
            // Arrange
            var stackOverflowException = new StackOverflowException();

            // Act
            var error = Error.New(stackOverflowException);

            // Assert
            error.Should().BeOfType<Error.Unexpected>();
            error.Exception.Match(None: () => new NotSupportedException(), Some: (ex) => ex).Should().Be(stackOverflowException);
        }

        [Fact]
        public void Expected_DoesNotHaveException()
        {
            // Arrange
            var code = "InvalidInput";

            // Act
            var error = new Error.Expected(code);

            // Assert
            error.Exception.Should().Be(F.None);
        }

        [Fact]
        public void Unexpected_DoesHaveException()
        {
            // Arrange
            var stackOverflowException = new StackOverflowException();

            // Act
            var error = new Error.Unexpected(stackOverflowException);

            // Assert
            error.Exception.Match(None: () => new NotSupportedException(), Some: (ex) => ex).Should().Be(stackOverflowException);
        }
    }
}
