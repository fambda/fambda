using System;
using FluentAssertions;
using Xunit;
using static Fambda.F;

namespace Fambda
{
    public class EitherExtTests
    {
        #region Map

        [Fact]
        public void Map_WhenRight_Succeeds()
        {
            // Arrange
            var value = 1;
            Either<string, int> either = Right(value);
            Func<int, string> toString = i => i.ToString();

            // Act
            var result = either.Map(toString);

            // Assert
            result.ToString().Should().Be("Right(1)");
        }

        [Fact]
        public void Map_WhenLeft_Succeeds()
        {
            // Arrange
            var value = "left";
            Either<string, int> either = Left(value);
            Func<int, string> toString = i => i.ToString();

            // Act
            var result = either.Map(toString);

            // Assert
            result.ToString().Should().Be("Left(left)");
        }

        #endregion

        #region Bind

        [Fact]
        public void Bind_InRightState_Succeeds()
        {
            // Arrange
            var value = 1;
            Either<string, int> either = Right(value);

            Func<int, Either<string, bool>> toTrueBoolWhenEitherRightAndIntOne = (i) =>
            {
                if (i.Equals(1))
                {
                    return Right(true);
                }
                else
                {
                    return Left("false");

                };
            };

            // Act
            var result = either.Bind(toTrueBoolWhenEitherRightAndIntOne);


            // Assert
            result.ToString().Should().Be($"Right({true})");
        }

        [Fact]
        public void Bind_InLeftState_Succeeds()
        {
            // Arrange
            var value = "value";
            var left = Left(value);
            Either<string, int> either = left;

            Func<int, Either<string, bool>> toTrueBoolWhenEitherRightAndIntOne = (i) =>
            {
                if (i.Equals(1))
                {
                    return Right(true);
                }
                else
                {
                    return Left("false");

                };
            };

            // Act
            var result = either.Bind(toTrueBoolWhenEitherRightAndIntOne);


            // Assert
            result.ToString().Should().Be("Left(value)");
        }

        #endregion
    }
}
