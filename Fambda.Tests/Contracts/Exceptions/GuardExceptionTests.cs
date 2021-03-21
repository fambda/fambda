using System;
using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Contracts.Exceptions
{
    [TestClass]
    public class GuardExceptionTests
    {
        [TestMethod]
        public void GuardExceptionShouldBeAssignableToSystemExceptionType()
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
