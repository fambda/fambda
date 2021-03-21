using System;
using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Contracts
{
    [TestClass]
    public class GuardExtensionsTests
    {
        [TestMethod]
        public void AgainstNullShouldReturnProvidedException()
        {
            // Arrange
            string value = null;
            var guardExceptionMessage = "Value must not be null.";
            var guardException = new GuardException(guardExceptionMessage);
            var guard = new Guard<string>(value, guardException);

            // Act
            Action act = ()=> { guard.AgainstNull(); };

            // Assert
            act.Should().Throw<GuardException>().WithMessage(guardExceptionMessage);
        }
    }
}
