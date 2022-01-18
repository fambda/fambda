using System;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests
{
    public class TryExtTests
    {
        #region Map

        [Fact]
        public void MapShouldSucceedWithMappingSuccessToSuccessResult()
        {
            // Arrange
            Func<string, Try<Uri>> createUri = (uri) => () =>
            {
                return new Uri(uri);
            };

            Func<Uri, string> func = (uri) => $"[{uri}]";

            // Act
            var result = createUri("https://fambda.net/").Map(func).Try().Match(
                Exception: (exception) => "Result=Exception",
                Success: (value) => $"Result=Success({value})"
            );

            // Assert
            result.Should().Be("Result=Success([https://fambda.net/])");
        }

        [Fact]
        public void MapShouldSucceedWithMappingException()
        {
            // Arrange
            Func<string, Try<Uri>> createUri = (uri) => () =>
            {
                return new Uri(uri);
            };

            Func<Uri, string> func = (uri) => $"[{uri}]";

            // Act
            var result = createUri("nonUri").Map(func).Try().Match(
                Exception: (exception) => $"Result=Exception({exception.GetType().Name})",
                Success: (value) => $"Result=Success({value})"
            );

            // Assert
            result.Should().Be("Result=Exception(UriFormatException)");
        }

        #endregion

        #region Bind

        [Fact]
        public void BindShouldSucceedWithBindingSuccessToSuccessResult()
        {
            // Arrange
            Func<string, Try<Uri>> createUri = (uri) => () =>
            {
                return new Uri(uri);
            };

            Func<Uri, Try<string>> createLink = (uri) => () => $"<a href='{uri}'>LINK</a>";

            // Act
            var result = createUri("https://fambda.net/").Bind(createLink).Try().Match(
                Exception: (exception) => "Result=Exception",
                Success: (value) => $"Result=Success({value})"
            );

            // Assert
            result.Should().Be("Result=Success(<a href='https://fambda.net/'>LINK</a>)");
        }

        [Fact]
        public void BindShouldSucceedWithException()
        {
            // Arrange
            Func<string, Try<Uri>> createUri = (uri) => () =>
            {
                return new Uri(uri);
            };

            Func<Uri, Try<string>> createLink = (uri) => () => $"<a href='{uri}'>LINK</a>";

            // Act
            var result = createUri("nonUri").Bind(createLink).Try().Match(
                Exception: (exception) => $"Result=Exception({exception.GetType().Name})",
                Success: (value) => $"Result=Success({value})"
            );

            // Assert
            result.Should().Be("Result=Exception(UriFormatException)");
        }

        #endregion
    }
}
