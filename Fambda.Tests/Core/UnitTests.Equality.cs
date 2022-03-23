using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class UnitTests
    {
        [Fact]
        public void Equals_Object_ReturnsTrue()
        {
            // Arrange
            var first = new Unit();
            object second = new Unit();

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_Object_ReturnsFalse()
        {
            // Arrange
            var first = new Unit();
            object second = "not a Unit";

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_Unit_ReturnsTrue()
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
