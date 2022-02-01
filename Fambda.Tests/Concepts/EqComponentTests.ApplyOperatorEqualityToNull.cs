using Fambda.Concepts.Objects;
using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda.Concepts
{
    public partial class EqComponentTests
    {
        [Fact]
        public void ApplyOperatorEqualityToNullMustReturnExpectedResultForClassDumbObjectNotNull()
        {
            // Arrange
            var bikeDumbClassObject = new BikeDumbClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeDumbClassObject>(bikeDumbClassObject);

            // Assert
            result.Should().BeFailure("Type does not override equality operator.");
        }

        [Fact]
        public void ApplyOperatorEqualityToNullMustReturnExpectedResultForClassOperatorObjectNotNull()
        {
            // Arrange
            var bikeOperatorClassObject = new BikeOperatorClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeOperatorClassObject>(bikeOperatorClassObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyOperatorEqualityToNullMustReturnExpectedResultForClassOperatorObjectDefaultNull()
        {
            // Arrange
            BikeOperatorClassObject bikeOperatorClassObject = default;

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeOperatorClassObject>(bikeOperatorClassObject);

            // Assert
            result.Should().BeFailure("Equality operator returned 'true' on expected non-equal objects.");
        }

        [Fact]
        public void ApplyOperatorEqualityToNullMustReturnExpectedResultForStructDumbObjectDefault()
        {
            // Arrange
            var bikeDumbStructObject = new BikeDumbStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeDumbStructObject>(bikeDumbStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyOperatorEqualityToNullMustReturnExpectedResultForStructOperatorObjectNotDefault()
        {
            // Arrange
            var bikeOperatorStructObject = new BikeOperatorStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeOperatorStructObject>(bikeOperatorStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyOperatorEqualityToNullMustReturnExpectedResultForStructOperatorObjectDefaultNull()
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
