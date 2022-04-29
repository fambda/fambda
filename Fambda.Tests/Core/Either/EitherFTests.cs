using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public class EitherFTests
    {
        [Fact]
        public void Left_Succeeds()
        {
            // Arrange
            var value = "value";

            // Act
            EitherLeft<string> left = Left<string>(value);

            // Assert
            left.ToString().Should().Be("Left(value)");
        }

        [Fact]
        public void Right_Succeeds()
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
