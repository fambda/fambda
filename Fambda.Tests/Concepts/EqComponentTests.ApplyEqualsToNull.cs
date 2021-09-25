using Fambda.Tests.Concepts.Objects;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Concepts
{
    public partial class EqComponentTests
    {
        [TestMethod]
        public void ApplyEqualsToNullMustReturnExpectedResultForClassObjectNotNull()
        {
            // Arrange
            var bikeDumbClassObject = new BikeDumbClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEqualsToNull<BikeDumbClassObject>(bikeDumbClassObject);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyEqualsToNullMustReturnExpectedResultForClassObjectDefaultNull()
        {
            // Arrange
            BikeDumbClassObject bikeClassObject = default;

            // Act
            var result = EqComponent.ApplyEqualsToNull<BikeDumbClassObject>(bikeClassObject);

            // Assert
            result.Should().BeFailure("Equals returned 'true' on expected non-equal objects.");
        }

        [TestMethod]
        public void ApplyEqualsToNullMustReturnExpectedResultForStructObjectDefault()
        {
            // Arrange
            BikeDumbStructObject bikeDumbStructObject = default;

            // Act
            var result = EqComponent.ApplyEqualsToNull<BikeDumbStructObject>(bikeDumbStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
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
