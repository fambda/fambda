using System;
using FluentAssertions;
using Xunit;

namespace Fambda.Contracts
{
    public class GuardExtensionsTests
    {
        [Fact]
        public void AgainstNull_WhenReferenceTypeValueIsNotNull_DoesnNotThrow()
        {
            // Arrange
            string value = "A not null value.";
            var guardExceptionMessage = "Value must not be null.";
            var guardException = new GuardException(guardExceptionMessage);
            var guard = new Guard<string?>(value, guardException);

            // Act
            Action act = () => { guard.AgainstNull(); };

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void AgainstNull_WhenNullableTypeValueIsNotNull_DoesNotThrow()
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

        [Fact]
        public void AgainstNull_WhenReferenceTypeValueIsNull_ReturnsProvidedException()
        {
            // Arrange
            string? value = null;
            var guardExceptionMessage = "Value must not be null.";
            var guardException = new GuardException(guardExceptionMessage);
            var guard = new Guard<string?>(value, guardException);

            // Act
            Action act = () => { guard.AgainstNull(); };

            // Assert
            act.Should().Throw<GuardException>().WithMessage(guardExceptionMessage);
        }

        [Fact]
        public void AgainstNull_WhenNullableTypeValueIsNull_ReturnsProvidedException()
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
