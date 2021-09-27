using Fambda.Tests.DataTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public partial class EitherTests
    {
        #region Either

        [TestMethod]
        public void ImplicitOperatorOverloadingShouldSucceedWithEitherLeft()
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
        public void ImplicitOperatorOverloadingShouldSucceedWithEitherRight()
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

        #endregion

        #region Match

        [TestMethod]
        public void MatchThroughFuncShouldMatchLeft()
        {
            // Arrange
            var either = new Either<string, int>("left");

            // Act
            var result = either.Match(l => $"MatchLeft({l})", r => $"MatchRight({r})");

            // Assert
            result.Should().Be("MatchLeft(left)");
        }

        [TestMethod]
        public void MatchThroughFuncShouldMatchRight()
        {
            // Arrange
            var either = new Either<string, int>(5);

            // Act
            var result = either.Match(l => $"MatchLeft({l})", r => $"MatchRight({r})");

            // Assert
            result.Should().Be("MatchRight(5)");
        }

        [TestMethod]
        public void MatchThroughActionShouldMatchLeft()
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
        public void MatchThroughActionShouldMatchRight()
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

        #endregion

        #region ToString

        [TestMethod]
        public void ToStringShouldReturnLeftRepresentation()
        {
            // Arrange
            var either = new Either<string, int>("left");

            // Act
            var result = either.ToString();

            // Assert
            result.Should().Be("Left(left)");
        }

        [TestMethod]
        public void ToStringShouldReturnRightRepresentation()
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
