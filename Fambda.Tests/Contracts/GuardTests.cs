using System;
using FluentAssertions;
using Xunit;

namespace Fambda.Contracts
{
    public class GuardTests
    {
        [Fact]
        public void Constructor_DoesNotThrow()
        {
            // Arrange
            var value = "value";
            var guardExceptionMessage = "Value must not be null.";
            var guardException = new GuardException(guardExceptionMessage);

            // Act
            Action ctor = () => new Guard<string>(value, guardException);

            // Assert
            ctor.Should().NotThrow();
        }
    }
}
