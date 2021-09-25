using Fambda.Tests.Concepts.Objects;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Concepts
{
    public partial class EqComponentTests
    {
        [TestMethod]
        public void ApplyEqualsOfTToNullMustReturnExpectedResultForClassObjectNotNull()
        {
            // Arrange
            var bikeDumbClassObject = new BikeDumbClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEqualsOfTToNull<BikeDumbClassObject>(bikeDumbClassObject);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyEqualsOfTToNullMustReturnExpectedResultForClassObjectDefaultNull()
        {
            // Arrange
            BikeDumbClassObject bikeClassObject = default;

            // Act
            var result = EqComponent.ApplyEqualsOfTToNull<BikeDumbClassObject>(bikeClassObject);

            // Assert
            result.Should().BeFailure("Equals returned 'true' on expected non-equal objects.");
        }

        [TestMethod]
        public void ApplyEqualsOfTToNullMustReturnExpectedResultForStructObjectDefault()
        {
            // Arrange
            BikeDumbStructObject bikeStructObject = default;

            // Act
            var result = EqComponent.ApplyEqualsOfTToNull<BikeDumbStructObject>(bikeStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
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
