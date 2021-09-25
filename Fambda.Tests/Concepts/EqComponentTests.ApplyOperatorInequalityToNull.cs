using Fambda.Tests.Concepts.Objects;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Concepts
{
    public partial class EqComponentTests
    {
        [TestMethod]
        public void ApplyInequalityOperatorToNullMustReturnExpectedResultForClassDumbObjectNotNull()
        {
            // Arrange
            var bikeDumbClassObject = new BikeDumbClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequalityToNull<BikeDumbClassObject>(bikeDumbClassObject);

            // Assert
            result.Should().BeFailure("Type does not override inequality operator.");
        }

        [TestMethod]
        public void ApplyInequalityOperatorToNullMustReturnExpectedResultForClassOperatorObjectNotNull()
        {
            // Arrange
            var bikeOperatorClassObject = new BikeOperatorClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequalityToNull<BikeOperatorClassObject>(bikeOperatorClassObject);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyInequalityOperatorToNullMustReturnExpectedResultForStructDumbObjectDefault()
        {
            // Arrange
            var bikeDumbStructObject = new BikeDumbStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequalityToNull<BikeDumbStructObject>(bikeDumbStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyInequalityOperatorToNullMustReturnExpectedResultForStructOperatorObjectNotDefault()
        {
            // Arrange
            var bikeOperatorStructObject = new BikeOperatorStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequalityToNull<BikeOperatorStructObject>(bikeOperatorStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyInequalityOperatorToNullMustReturnExpectedResultForStructOperatorObjectDefaultNull()
        {
            // Arrange
            BikeOperatorStructObject bikeOperatorStructObject = default;

            // Act
            var result = EqComponent.ApplyOperatorInequalityToNull<BikeOperatorStructObject>(bikeOperatorStructObject);

            // Assert
            result.Should().BeSuccess();
        }
    }
}
