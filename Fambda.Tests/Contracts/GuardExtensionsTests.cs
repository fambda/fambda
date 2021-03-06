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
        public void AgainstNullShouldNotThrowWhenReferenceTypeValueIsNotNull()
        {
            // Arrange
            string value = "A not null value.";
            var guardExceptionMessage = "Value must not be null.";
            var guardException = new GuardException(guardExceptionMessage);
            var guard = new Guard<string>(value, guardException);

            // Act
            Action act = () => { guard.AgainstNull(); };

            // Assert
            act.Should().NotThrow();
        }

        [TestMethod]
        public void AgainstNullShouldNotThrowWhenNullableTypeValueIsNotNull()
        {
            // Arrange
            Nullable<int> value = 1;
            var guardExceptionMessage = "Value must not be null.";
            var guardException = new GuardException(guardExceptionMessage);
            var guard = new Guard<Nullable<int>>(value, guardException);

            // Act
            Action act = () => { guard.AgainstNull(); };

            // Assert
            act.Should().NotThrow();
        }

        [TestMethod]
        public void AgainstNullShouldReturnProvidedExceptionWhenReferenceTypeValueIsNull()
        {
            // Arrange
            string value = null;
            var guardExceptionMessage = "Value must not be null.";
            var guardException = new GuardException(guardExceptionMessage);
            var guard = new Guard<string>(value, guardException);

            // Act
            Action act = () => { guard.AgainstNull(); };

            // Assert
            act.Should().Throw<GuardException>().WithMessage(guardExceptionMessage);
        }

        [TestMethod]
        public void AgainstNullShouldReturnProvidedExceptionWhenNullableTypeValueIsNull()
        {
            // Arrange
            int? value = null;
            var guardExceptionMessage = "Value must not be null.";
            var guardException = new GuardException(guardExceptionMessage);
            var guard = new Guard<int?>(value, guardException);

            // Act
            Action act = () => { guard.AgainstNull(); };

            // Assert
            act.Should().Throw<GuardException>().WithMessage(guardExceptionMessage);
        }
    }
}
