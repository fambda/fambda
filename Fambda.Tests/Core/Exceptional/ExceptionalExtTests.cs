using System;
using Fambda.DataTypes;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public class ExceptionalExtTests
    {
        #region Map

        [Fact]
        public void Map_WhenException_Succeeds()
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
        public void Map_WhenSuccess_Succeeds()
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
        public void Bind_WhenException_Succeeds()
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
        public void Bind_WhenSuccess_Succeeds()
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

        #region Apply

        [Fact]
        public void Apply_SuccessArgsOnUnaryFunc_ReturnsException()
        {
            // Arrange
            var exception = new SomeException("Some exception");
            Exceptional<Func<int, string>> exceptional = exception;

            Exceptional<int> optionArg = 1;

            // Act
            var result = exceptional
                            .Apply(optionArg);

            // Assert
            result.ToString().Should().Be("Exception(Some exception)");
        }

        [Fact]
        public void Apply_ExceptionArgsOnUnaryFunc_ReturnsException()
        {
            // Arrange
            Func<int, string> toArrowString = t => "-> " + t.ToString();
            Exceptional<Func<int, string>> exceptional = toArrowString;

            var intException = new SomeException("Some int exception");
            Exceptional<int> optionArg = intException;

            // Act
            var result = exceptional
                            .Apply(optionArg);

            // Assert
            result.ToString().Should().Be("Exception(Some int exception)");
        }

        [Fact]
        public void Apply_SuccessArgsOnUnaryFunc_ReturnsSuccessWithExpectedValue()
        {
            // Arrange
            Func<int, string> toArrowString = t => "-> " + t.ToString();
            Exceptional<Func<int, string>> exceptional = toArrowString;

            Exceptional<int> optionArg = 1;

            // Act
            var result = exceptional
                            .Apply(optionArg);

            // Assert
            result.ToString().Should().Be("Success(-> 1)");
        }

        [Fact]
        public void Apply_SuccessArgsOnBinaryFunc_ReturnsException()
        {
            // Arrange
            var exception = new SomeException("Some exception");
            Exceptional<Func<int, int, string>> exceptional = exception;

            Exceptional<int> optionArg1 = 1;
            Exceptional<int> optionArg2 = 2;

            // Act
            var result = exceptional
                            .Apply(optionArg1)
                            .Apply(optionArg2);

            // Assert
            result.ToString().Should().Be("Exception(Some exception)");
        }

        [Fact]
        public void Apply_ExceptionArgsOnBinaryFunc_ReturnsException()
        {
            // Arrange
            Func<int, int, string> toArrowString = (x, y) => "-> " + (x + y).ToString();
            Exceptional<Func<int, int, string>> exceptional = toArrowString;

            var intException = new SomeException("Some int exception");
            Exceptional<int> optionArg1 = intException;
            Exceptional<int> optionArg2 = 2;

            // Act
            var result = exceptional
                            .Apply(optionArg1)
                            .Apply(optionArg2);

            // Assert
            result.ToString().Should().Be("Exception(Some int exception)");
        }

        [Fact]
        public void Apply_SuccessArgsOnBinaryFunc_ReturnsSuccessWithExpectedValue()
        {
            // Arrange
            Func<int, int, string> toArrowString = (x, y) => "-> " + (x + y).ToString();
            Exceptional<Func<int, int, string>> exceptional = toArrowString;

            Exceptional<int> optionArg1 = 1;
            Exceptional<int> optionArg2 = 2;

            // Act
            var result = exceptional
                            .Apply(optionArg1)
                            .Apply(optionArg2);

            // Assert
            result.ToString().Should().Be("Success(-> 3)");
        }

        #endregion
    }
}
