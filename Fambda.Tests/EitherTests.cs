using System;
using Fambda.Tests.DataTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
