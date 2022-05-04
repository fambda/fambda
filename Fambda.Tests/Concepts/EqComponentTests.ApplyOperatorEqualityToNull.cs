using Fambda.Concepts.Objects;
using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda.Concepts
{
    public partial class EqComponentTests
    {
        [Fact]
        public void ApplyOperatorEqualityToNull_ForClassDumbObjectNotNull_ReturnsExpectedResult()
        {
            // Arrange
            var bikeDumbClassObject = new BikeDumbClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeDumbClassObject>(bikeDumbClassObject);

            // Assert
            result.Should().BeFailure("Type does not override equality operator.");
        }

        [Fact]
        public void ApplyOperatorEqualityToNull_ForClassOperatorObjectNotNull_ReturnsExpectedResult()
        {
            // Arrange
            var bikeOperatorClassObject = new BikeOperatorClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeOperatorClassObject>(bikeOperatorClassObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyOperatorEqualityToNull_ForClassOperatorObjectDefaultNull_ReturnsExpectedResult()
        {
            // Arrange
            BikeOperatorClassObject? bikeOperatorClassObject = default;

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeOperatorClassObject>(bikeOperatorClassObject);

            // Assert
            result.Should().BeFailure("Equality operator returned 'true' on expected non-equal objects.");
        }

        [Fact]
        public void ApplyOperatorEqualityToNull_ForStructDumbObjectDefault_ReturnsExpectedResult()
        {
            // Arrange
            var bikeDumbStructObject = new BikeDumbStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeDumbStructObject>(bikeDumbStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyOperatorEqualityToNull_ForStructOperatorObjectNotDefault_ReturnsExpectedResult()
        {
            // Arrange
            var bikeOperatorStructObject = new BikeOperatorStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeOperatorStructObject>(bikeOperatorStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyOperatorEqualityToNull_ForStructOperatorObjectDefaultNull_ReturnsExpectedResult()
        {
            // Arrange
            BikeOperatorStructObject bikeOperatorStructObject = default;

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeOperatorStructObject>(bikeOperatorStructObject);

            // Assert
            result.Should().BeSuccess();
        }
    }
}
