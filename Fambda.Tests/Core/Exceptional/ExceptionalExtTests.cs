using System;
using Fambda.Tests.DataTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public class ExceptionalExtTests
    {
        #region Map

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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


        [TestMethod]
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

        #endregion
    }
}
