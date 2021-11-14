using System;
using Fambda.Contracts;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests.Contracts
{
    public class GuardExtensionsTests
    {
        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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



        [Fact]
        public void EachAgainstNullMustNotThrowWhenEachObjectIsNotNull()
        {
            // Arrange
            object[] value = new object[] { new object(), new object() };


            var guardExceptionMessage = "Value must not be null.";
            var guardException = new GuardException(guardExceptionMessage);
            var guard = new Guard<object[]>(value, guardException);

            // Act
            Action act = () => { guard.EachAgainstNull(); };

            // Assert
            act.Should().NotThrow();
        }


        [Fact]
        public void EachAgainstNullMustNotThrowWhenSomeObjectIsNull()
        {
            // Arrange
            object[] value = new object[] { new object(), null, new object() };


            var guardExceptionMessage = "Value must not be null.";
            var guardException = new GuardException(guardExceptionMessage);
            var guard = new Guard<object[]>(value, guardException);

            // Act
            Action act = () => { guard.EachAgainstNull(); };

            // Assert
            act.Should().Throw<GuardException>().WithMessage(guardExceptionMessage);
        }
    }
}
