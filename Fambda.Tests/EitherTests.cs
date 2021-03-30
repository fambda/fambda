using System;
using Fambda.Tests.DataTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class EitherTests
    {
        #region EitherLeft<L>

        [TestMethod]
        public void EitherLeftCtorShouldSucceed()
        {
            // Arrange
            var value = "left";

            // Act
            Action ctor = () => { new EitherLeft<string>(value); };

            // Assert
            ctor.Should().NotThrow();
        }

        [TestMethod]
        public void EitherLeftShouldHaveExpectedValue()
        {
            // Arrange
            var value = "left";
            var eitherLeft = new EitherLeft<string>(value);

            // Act
            var result = eitherLeft.Value;

            // Assert
            result.Should().Be(value);
        }

        [TestMethod]
        public void EitherLeftToStringShouldProvideExpectedRepresentation()
        {
            // Arrange
            var value = "left";
            var expectedResult = $"Left({value})";
            var eitherLeft = new EitherLeft<string>(value);

            // Act
            var result = eitherLeft.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }

        #endregion

        #region EitherRight<R>

        [TestMethod]
        public void EitherRightCtorShouldSucceed()
        {
            // Arrange
            var value = "right";

            // Act
            Action ctor = () => { new EitherRight<string>(value); };

            // Assert
            ctor.Should().NotThrow();
        }

        [TestMethod]
        public void EitherRightShouldHaveExpectedValue()
        {
            // Arrange
            var value = "right";
            var eitherRight = new EitherRight<string>(value);

            // Act
            var result = eitherRight.Value;

            // Assert
            result.Should().Be(value);
        }

        [TestMethod]
        public void EitherRightToStringShouldProvideExpectedRepresentation()
        {
            // Arrange
            var value = "right";
            var expectedResult = $"Right({value})";
            var eitherRight = new EitherRight<string>(value);

            // Act
            var result = eitherRight.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }

        #endregion

        #region Either

        [TestMethod]
        public void EitherCtorThroughImplicitOperatorOverloadingShouldSucceedWithEitherLeft()
        {
            // Arrange
            var value = "value";
            var eitherLeft = new EitherLeft<string>(value);

            // Act
            Either<string, int> either = eitherLeft;
            var result = either.ToString();

            // Assert
            result.Should().Be("Left(value)");
        }

        [TestMethod]
        public void EitherCtorThroughImplicitOperatorOverloadingShouldSucceedWithEitherRight()
        {
            // Arrange
            var value = 1;
            var eitherRight = new EitherRight<int>(value);

            // Act
            Either<string, int> either = eitherRight;
            var result = either.ToString();

            // Assert
            result.Should().Be("Right(1)");
        }

        [TestMethod]
        public void EitherMatchThroughFuncShouldMatchLeft()
        {
            // Arrange
            var either = new Either<string, int>("left");

            // Act
            var result = either.Match(l => $"MatchLeft({l})", r => $"MatchRight({r})");

            // Assert
            result.Should().Be("MatchLeft(left)");
        }

        [TestMethod]
        public void EitherMatchThroughFuncShouldMatchRight()
        {
            // Arrange
            var either = new Either<string, int>(5);

            // Act
            var result = either.Match(l => $"MatchLeft({l})", r => $"MatchRight({r})");

            // Assert
            result.Should().Be("MatchRight(5)");
        }

        [TestMethod]
        public void EitherMatchThroughActionShouldMatchLeft()
        {
            // Arrange
            Log.Init();
            var either = new Either<string, int>("left");

            // Act
            either.Match(
                    Left: (l) => Log.Message($"MatchLeft({l})"),
                    Right: (r) => Log.Message($"MatchRight{r}")
                );
            var result = Log.Read();

            // Assert
            result.Should().Be("MatchLeft(left)");
        }

        [TestMethod]
        public void EitherMatchThroughActionShouldMatchRight()
        {
            // Arrange
            Log.Init();
            var either = new Either<string, int>(5);

            // Act
            either.Match(
                    Left: (l) => Log.Message($"MatchLeft({l})"),
                    Right: (r) => Log.Message($"MatchRight({r})")
                );
            var result = Log.Read();

            // Assert
            result.Should().Be("MatchRight(5)");
        }

        [TestMethod]
        public void EitherToStringShouldReturnLeftRepresentation()
        {
            // Arrange
            var either = new Either<string, int>("left");

            // Act
            var result = either.ToString();

            // Assert
            result.Should().Be("Left(left)");
        }

        [TestMethod]
        public void EitherToStringShouldReturnRightRepresentation()
        {
            // Arrange
            var either = new Either<string, int>(5);

            // Act
            var result = either.ToString();

            // Assert
            result.Should().Be("Right(5)");
        }




        #endregion

        #region Either.F

        [TestMethod]
        public void FLeftShouldSucceed()
        {
            // Arrange
            var value = "value";

            // Act
            EitherLeft<string> left = Left<string>(value);

            // Assert
            left.ToString().Should().Be("Left(value)");
        }

        [TestMethod]
        public void FRightShouldSucceed()
        {
            // Arrange
            var value = "value";

            // Act
            EitherRight<string> right = Right<string>(value);

            // Assert
            right.ToString().Should().Be("Right(value)");
        }

        #endregion

        #region EitherExt

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


        #endregion
    }
}
