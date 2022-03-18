using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public class UnitFTests
    {
        [Fact]
        public void Unit_ReturnsDefaultUnit()
        {
            // Arrange
            var expected = default(Unit);

            // Act
            var result = F.Unit();

            // Assert
            result.Should().Be(expected);
        }
    }
}
