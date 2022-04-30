using System;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public class TryExtTests
    {
        #region Map

        [Fact]
        public void Map_WithMappingException_Succeeds()
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

        [Fact]
        public void Map_WithMappingSuccess_Succeeds()
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

        #endregion

        #region Bind

        [Fact]
        public void Bind_WithException_Succeeds()
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

        [Fact]
        public void Bind_WithBindingSuccess_Succeeds()
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

        #endregion
    }
}
