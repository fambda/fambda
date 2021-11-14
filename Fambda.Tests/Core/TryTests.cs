using System;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests
{
    public class TryTests
    {
        [Fact]
        public void TryShouldMatchToSuccess()
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
        public void TryShouldMatchToException()
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
