using Fambda.Concepts.Objects;
using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda.Concepts
{
    public partial class EqComponentTests
    {
        [Fact]
        public void ApplyEqualsToNullMustReturnExpectedResultForClassObjectNotNull()
        {
            // Arrange
            var bikeDumbClassObject = new BikeDumbClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEqualsToNull<BikeDumbClassObject>(bikeDumbClassObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyEqualsToNullMustReturnExpectedResultForClassObjectDefaultNull()
        {
            // Arrange
            BikeDumbClassObject? bikeClassObject = default;

            // Act
            var result = EqComponent.ApplyEqualsToNull<BikeDumbClassObject>(bikeClassObject);

            // Assert
            result.Should().BeFailure("Equals returned 'true' on expected non-equal objects.");
        }

        [Fact]
        public void ApplyEqualsToNullMustReturnExpectedResultForStructObjectDefault()
        {
            // Arrange
            BikeDumbStructObject bikeDumbStructObject = default;

            // Act
            var result = EqComponent.ApplyEqualsToNull<BikeDumbStructObject>(bikeDumbStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyEqualsToNullMustReturnExpectedResultForStructObject()
        {
            // Arrange
            var bikeDumbStructObject = new BikeDumbStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEqualsToNull<BikeDumbStructObject>(bikeDumbStructObject);

            // Assert
            result.Should().BeSuccess();
        }
    }
}
