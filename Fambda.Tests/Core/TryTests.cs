using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public class TryTests
    {
        [TestMethod]
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

        [TestMethod]
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
