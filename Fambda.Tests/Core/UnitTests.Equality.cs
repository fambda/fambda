using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class UnitTests
    {
        [Fact]
        public void Equals_ReturnsTrue()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }
    }
}
