using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class UnitTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Null_MustPass()
        {
            // Arrange
            Unit unit = new Unit();

            // Act
            var result = new Equable().Null(unit);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Equal_MustPass()
        {
            // Arrange
            Unit first = new Unit();
            Unit second = new Unit();

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_Unequal_MustNotPass()
        {
            // Arrange
            Unit first = new Unit();
            Unit second = new Unit();

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().NotPass("Equals returned 'true' on expected non-equal objects.",
                                    "Typed Equals returned 'true' on expected non-equal objects.",
                                    "Equality operator returned 'true' on expected non-equal objects.",
                                    "Inequality operator returned 'false' on expected non-equal objects.");
        }
    }
}
