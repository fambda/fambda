using Fambda.DataTypes;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class EitherTests
    {
        #region Either

        [Fact]
        public void ImplicitConversion_EitherLeftToEither_ReturnsEitherInLeft()
        {
            // Arrange
            var value = "value";
            var eitherLeft = F.Left<string>(value);

            // Act
            Either<string, int> either = eitherLeft;
            var result = either.IsLeft;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ImplicitConversion_EitherRightToEither_ReturnsEitherInRight()
        {
            // Arrange
            var value = 1;
            var eitherRight = F.Right<int>(value);

            // Act
            Either<string, int> either = eitherRight;
            var result = either.IsRight;

            // Assert
            result.Should().BeTrue();
        }

        #endregion

        #region Match

        [Fact]
        public void Match_ThroughFunc_ReturnsLeftResult()
        {
            // Arrange
            Either<string, int> either = F.Left<string>("left");

            // Act
            var result = either.Match(l => $"Result=Left({l})", r => $"Result=Right({r})");

            // Assert
            result.Should().Be("Result=Left(left)");
        }

        [Fact]
        public void Match_ThroughFunc_ReturnsRightResult()
        {
            // Arrange
            Either<string, int> either = F.Right<int>(5);

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
            Either<string, int> either = F.Left<string>("left");

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
            Either<string, int> either = F.Right<int>(5);

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
        public void ToString_ReturnsLeftRepresentation()
        {
            // Arrange
            Either<string, int> either = F.Left<string>("left");

            // Act
            var result = either.ToString();

            // Assert
            result.Should().Be("Left(left)");
        }

        [Fact]
        public void ToString_ReturnsRightRepresentation()
        {
            // Arrange
            Either<string, int> either = F.Right<int>(5);

            // Act
            var result = either.ToString();

            // Assert
            result.Should().Be("Right(5)");
        }

        #endregion
    }
}
