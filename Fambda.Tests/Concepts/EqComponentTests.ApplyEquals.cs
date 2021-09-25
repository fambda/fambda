using Fambda.Tests.Concepts.Objects;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Concepts
{
    public partial class EqComponentTests
    {
        #region Class

        [TestMethod]
        public void ApplyEqualsMustReturnExpectedResultForClassObjectsWithSameEqualsResultAndExpectedEqualTrue()
        {
            // Arrange
            var first = new BikeWithEqualsClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsClassObject>(first, second, true);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyEqualsMustReturnExpectedResultForClassObjectsWithSameEqualsResultAndExpectedEqualFalse()
        {
            // Arrange
            var first = new BikeWithEqualsClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsClassObject>(first, second, false);

            // Assert
            result.Should().BeFailure("Equals returned 'true' on expected non-equal objects.");
        }

        [TestMethod]
        public void ApplyEqualsMustReturnExpectedResultForClassObjectsWithDifferentEqualsResultAndExpectedEqualTrue()
        {
            // Arrange
            var first = new BikeWithEqualsClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsClassObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsClassObject>(first, second, true);

            // Assert
            result.Should().BeFailure("Equals returned 'false' on expected equal objects.");
        }

        [TestMethod]
        public void ApplyEqualsMustReturnExpectedResultForClassObjectsWithDifferentEqualsResultAndExpectedEqualFalse()
        {
            // Arrange
            var first = new BikeWithEqualsClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsClassObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsClassObject>(first, second, false);

            // Assert
            result.Should().BeSuccess();
        }

        #endregion

        #region Struct

        [TestMethod]
        public void ApplyEqualsMustReturnExpectedResultForStructObjectsWithSameEqualsResultAndExpectedEqualTrue()
        {
            // Arrange
            var first = new BikeWithEqualsStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsStructObject>(first, second, true);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyEqualsMustReturnExpectedResultForStructObjectsWithSameEqualsResultAndExpectedEqualFalse()
        {
            // Arrange
            var first = new BikeWithEqualsStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsStructObject>(first, second, false);

            // Assert
            result.Should().BeFailure("Equals returned 'true' on expected non-equal objects.");
        }

        [TestMethod]
        public void ApplyEqualsMustReturnExpectedResultForStructObjectsWithDifferentEqualsResultAndExpectedEqualTrue()
        {
            // Arrange
            var first = new BikeWithEqualsStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsStructObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsStructObject>(first, second, true);

            // Assert
            result.Should().BeFailure("Equals returned 'false' on expected equal objects.");
        }

        [TestMethod]
        public void ApplyEqualsMustReturnExpectedResultForStructObjectsWithDifferentEqualsResultAndExpectedEqualFalse()
        {
            // Arrange
            var first = new BikeWithEqualsStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsStructObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsStructObject>(first, second, false);

            // Assert
            result.Should().BeSuccess();
        }

        #endregion
    }
}
