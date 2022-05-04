using System;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class TryTests
    {
        [Fact]
        public void Match_ReturnsSuccessResult()
        {
            // Arrange
            Func<string, Try<Uri>> createUri = (uri) => () =>
            {
                return new Uri(uri);
            };

            // Act
            var result = createUri("https://fambda.net/").Try().Match(
                Exception: (exception) => "Result=Exception",
                Success: (value) => $"Result=Success({value})"
            );

            // Assert
            result.Should().Be("Result=Success(https://fambda.net/)");
        }

        [Fact]
        public void Match_ReturnsExceptionResult()
        {
            // Arrange
            Func<string, Try<Uri>> createUri = (uri) => () =>
            {
                return new Uri(uri);
            };

            // Act
            var result = createUri("nonUri").Try().Match(
                Exception: (exception) => $"Result=Exception({exception.GetType().Name})",
                Success: (value) => $"Result=Success({value})"
            );

            // Assert
            result.Should().Be("Result=Exception(UriFormatException)");
        }
    }
}
