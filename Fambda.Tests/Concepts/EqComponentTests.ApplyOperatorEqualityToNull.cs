using Fambda.Tests.Concepts.Objects;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Concepts
{
    public partial class EqComponentTests
    {
        [TestMethod]
        public void ApplyOperatorEqualityToNullMustReturnExpectedResultForClassDumbObjectNotNull()
        {
            // Arrange
            var bikeDumbClassObject = new BikeDumbClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeDumbClassObject>(bikeDumbClassObject);

            // Assert
            result.Should().BeFailure("Type does not override equality operator.");
        }

        [TestMethod]
        public void ApplyOperatorEqualityToNullMustReturnExpectedResultForClassOperatorObjectNotNull()
        {
            // Arrange
            var bikeOperatorClassObject = new BikeOperatorClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeOperatorClassObject>(bikeOperatorClassObject);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyOperatorEqualityToNullMustReturnExpectedResultForClassOperatorObjectDefaultNull()
        {
            // Arrange
            BikeOperatorClassObject bikeOperatorClassObject = default;

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeOperatorClassObject>(bikeOperatorClassObject);

            // Assert
            result.Should().BeFailure("Equality operator returned 'true' on expected non-equal objects.");
        }

        [TestMethod]
        public void ApplyOperatorEqualityToNullMustReturnExpectedResultForStructDumbObjectDefault()
        {
            // Arrange
            var bikeDumbStructObject = new BikeDumbStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeDumbStructObject>(bikeDumbStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyOperatorEqualityToNullMustReturnExpectedResultForStructOperatorObjectNotDefault()
        {
            // Arrange
            var bikeOperatorStructObject = new BikeOperatorStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEqualityToNull<BikeOperatorStructObject>(bikeOperatorStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
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
