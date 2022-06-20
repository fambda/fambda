using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class EitherLeftTests
    {
        [Fact]
        public void ToString_ReturnsExpectedRepresentation()
        {
            // Arrange
            var value = "left";
            var expectedResult = $"Left({value})";
            var eitherLeft = F.Left<string>(value);

            // Act
            var result = eitherLeft.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
