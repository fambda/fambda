using Fambda.DataTypes;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class EitherTests
    {
        #region Either

        [Fact]
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

        [Fact]
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

        [Fact]
        public void Match_ThroughFunc_ReturnsLeftResult()
        {
            // Arrange
            var either = new Either<string, int>("left");

            // Act
            var result = either.Match(l => $"Result=Left({l})", r => $"Result=Right({r})");

            // Assert
            result.Should().Be("Result=Left(left)");
        }

        [Fact]
        public void Match_ThroughFunc_ReturnsRightResult()
        {
            // Arrange
            var either = new Either<string, int>(5);

            // Act
            var result = either.Match(l => $"Result=Left({l})", r => $"Result=Right({r})");

            // Assert
            result.Should().Be("Result=Right(5)");
        }

        [Fact]
        public void Match_ThroughAction_UsesLeftResult()
        {
            // Arrange
            Log.Init();
            var either = new Either<string, int>("left");

            // Act
            either.Match(
                    Left: (l) => Log.Message($"Result=Left({l})"),
                    Right: (r) => Log.Message($"Result=Right{r}")
                );
            var result = Log.Read();

            // Assert
            result.Should().Be("Result=Left(left)");
        }

        [Fact]
        public void Match_ThroughAction_UsesRightResult()
        {
            // Arrange
            Log.Init();
            var either = new Either<string, int>(5);

            // Act
            either.Match(
                    Left: (l) => Log.Message($"Result=Left({l})"),
                    Right: (r) => Log.Message($"Result=Right({r})")
                );
            var result = Log.Read();

            // Assert
            result.Should().Be("Result=Right(5)");
        }

        #endregion

        #region ToString

        [Fact]
        public void ToStringShouldReturnLeftRepresentation()
        {
            // Arrange
            var either = new Either<string, int>("left");

            // Act
            var result = either.ToString();

            // Assert
            result.Should().Be("Left(left)");
        }

        [Fact]
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
