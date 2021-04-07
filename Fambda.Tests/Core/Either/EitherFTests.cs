using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class EitherFTests
    {
        [TestMethod]
        public void LeftShouldSucceed()
        {
            // Arrange
            var value = "value";

            // Act
            EitherLeft<string> left = Left<string>(value);

            // Assert
            left.ToString().Should().Be("Left(value)");
        }

        [TestMethod]
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
