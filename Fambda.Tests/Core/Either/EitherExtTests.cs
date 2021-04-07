using System;
using Fambda.Tests.DataTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class EitherExtTests
    {
        #region Map

        [TestMethod]
        public void EitherMapShouldSucceedWhenRight()
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

        [TestMethod]
        public void EitherMapShouldSucceedWhenLeft()
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

        [TestMethod]
        public void EitherBindShouldSucceedWhenRight()
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
            result.Right.Should().BeTrue();
        }

        [TestMethod]
        public void EitherBindShouldSucceedWhenLeft()
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
            result.Left.Should().Be("value");
        }

        #endregion
    }
}
