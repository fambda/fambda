using System;
using Fambda.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Contracts
{
    [TestClass]
    public class GuardTests
    {
        [TestMethod]
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

        [TestMethod]
        public void CreateShouldFail()
        {
            // Arrange
            string value = null;
            GuardException guardException = null;

            // Act
            Action ctor = () => new Guard<string>(value, guardException);

            // Assert
            ctor.Should().Throw<GuardException>();
        }
    }
}
