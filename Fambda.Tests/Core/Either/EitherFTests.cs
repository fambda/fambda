using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda.Tests
{
    public class EitherFTests
    {
        [Fact]
        public void LeftShouldSucceed()
        {
            // Arrange
            var value = "value";

            // Act
            EitherLeft<string> left = Left<string>(value);

            // Assert
            left.ToString().Should().Be("Left(value)");
        }

        [Fact]
        public void RightShouldSucceed()
        {
            // Arrange
            var value = "value";

            // Act
            EitherRight<string> right = Right<string>(value);

            // Assert
            right.ToString().Should().Be("Right(value)");
        }
    }
}
