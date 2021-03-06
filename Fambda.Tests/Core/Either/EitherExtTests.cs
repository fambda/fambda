using System;
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
        public void MapShouldSucceedWhenRight()
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
        public void MapShouldSucceedWhenLeft()
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
        public void BindShouldSucceedWhenRight()
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
        public void BindShouldSucceedWhenLeft()
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
