using Fambda.Concepts.Objects;
using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda.Concepts
{
    public partial class EqComponentTests
    {
        [Fact]
        public void ApplyEqualsOfTToNullMustReturnExpectedResultForClassObjectNotNull()
        {
            // Arrange
            var bikeDumbClassObject = new BikeDumbClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEqualsOfTToNull<BikeDumbClassObject>(bikeDumbClassObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyEqualsOfTToNullMustReturnExpectedResultForClassObjectDefaultNull()
        {
            // Arrange
            BikeDumbClassObject? bikeClassObject = default;

            // Act
            var result = EqComponent.ApplyEqualsOfTToNull<BikeDumbClassObject>(bikeClassObject);

            // Assert
            result.Should().BeFailure("Equals returned 'true' on expected non-equal objects.");
        }

        [Fact]
        public void ApplyEqualsOfTToNullMustReturnExpectedResultForStructObjectDefault()
        {
            // Arrange
            BikeDumbStructObject bikeStructObject = default;

            // Act
            var result = EqComponent.ApplyEqualsOfTToNull<BikeDumbStructObject>(bikeStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyEqualsOfTToNullMustReturnExpectedResultForStructObject()
        {
            // Arrange
            var bikeDumbStructObject = new BikeDumbStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEqualsOfTToNull<BikeDumbStructObject>(bikeDumbStructObject);

            // Assert
            result.Should().BeSuccess();
        }
    }
}
