using System;
using Fambda.Tests.DataTypes;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests
{
    public class ExceptionalExtTests
    {
        #region Map

        [Fact]
        public void MapShouldNotInvokeFuncWhenException()
        {
            // Arrange
            var exception = new SomeException("Some exception");
            Exceptional<int> exceptional = exception;

            Func<int, int> increment = i => i + 1;

            // Act
            var result = exceptional.Map(increment);

            // Assert
            result.ToString().Should().Be("Exception(Some exception)");
        }

        [Fact]
        public void MapShouldSucceedWhenSuccess()
        {
            // Arrange
            var value = 1;
            Exceptional<int> exceptional = value;

            Func<int, int> increment = i => i + 1;

            // Act
            var result = exceptional.Map(increment);

            // Assert
            result.ToString().Should().Be("Success(2)");
        }

        #endregion

        #region Bind


        [Fact]
        public void BindShouldNotInvokeFuncWhenException()
        {
            // Arrange
            var exception = new SomeException("Some exception");
            Exceptional<int> exceptional = exception;

            Exceptional<bool> exceptionalWithSuccess = true;

            var anotherException = new SomeException("Some another exception");
            Exceptional<bool> exceptionalWithException = anotherException;


            Func<int, Exceptional<bool>> toAnotherExceptional = (i) =>
            {
                if (i.Equals(1))
                {
                    return exceptionalWithSuccess;
                }
                else
                {
                    return exceptionalWithException;
                }
            };

            // Act
            var result = exceptional.Bind(toAnotherExceptional);

            // Assert
            result.ToString().Should().Be(exceptional.ToString());
        }

        [Fact]
        public void BindShouldSucceedWhenSuccess()
        {
            // Arrange
            var value = 1;
            Exceptional<int> exceptional = value;

            Exceptional<bool> exceptionalWithSuccess = true;

            var exception = new SomeException("Some exception");
            Exceptional<bool> exceptionalWithException = exception;


            Func<int, Exceptional<bool>> toAnotherExceptional = (i) =>
            {
                if (i.Equals(1))
                {
                    return exceptionalWithSuccess;
                }
                else
                {
                    return exceptionalWithException;
                }
            };

            // Act
            var result = exceptional.Bind(toAnotherExceptional);

            // Assert
            result.Should().Be(exceptionalWithSuccess);
        }

        #endregion
    }
}
