using System;
using FluentAssertions;
using Xunit;

namespace Fambda.Contracts
{
    public class GuardTests
    {
        [Fact]
        public void CreateShouldSucceed()
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

        [Fact]
        public void CreateShouldFail()
        {
            // Arrange
            string value = null;
            GuardException? guardException = null;

            // Act
            Action ctor = () => new Guard<string>(value, guardException);

            // Assert
            ctor.Should().Throw<GuardException>();
        }
    }
}
