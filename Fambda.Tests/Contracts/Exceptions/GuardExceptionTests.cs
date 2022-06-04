using System;
using FluentAssertions;
using Xunit;

namespace Fambda.Contracts.Exceptions
{
    public class GuardExceptionTests
    {
        [Fact]
        public void GuardException_AssignableToSystemExceptionType()
        {
            // Arrange
            var exceptionType = typeof(Exception);

            // Act
            var exception = new GuardException("message");

            // Assert
            exception.Should().BeAssignableTo(exceptionType);
        }
    }
}
