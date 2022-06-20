using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class EitherRightTests
    {
        [Fact]
        public void ToString_ReturnsExpectedRepresentation()
        {
            // Arrange
            var value = "right";
            var expectedResult = $"Right({value})";
            var eitherRight = F.Right<string>(value);

            // Act
            var result = eitherRight.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
