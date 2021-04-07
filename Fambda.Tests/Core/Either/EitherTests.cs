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
    }
}
