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
        public void ApplyEqualsOfTMustReturnExpectedResultForClassObjectsWithSameEqualsResultAndExpectedEqualTrue()
        {
            // Arrange
            var first = new BikeWithEqualsOfTClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsOfTClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEqualsOfT<BikeWithEqualsOfTClassObject>(first, second, true);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyEqualsOfTMustReturnExpectedResultForClassObjectsWithSameEqualsResultAndExpectedEqualFalse()
        {
            // Arrange
            var first = new BikeWithEqualsOfTClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsOfTClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEqualsOfT<BikeWithEqualsOfTClassObject>(first, second, false);

            // Assert
            result.Should().BeFailure("Typed Equals returned 'true' on expected non-equal objects.");
        }

        [TestMethod]
        public void ApplyEqualsOfTMustReturnExpectedResultForClassObjectsWithDifferentEqualsResultAndExpectedEqualTrue()
        {
            // Arrange
            var first = new BikeWithEqualsOfTClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsOfTClassObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyEqualsOfT<BikeWithEqualsOfTClassObject>(first, second, true);

            // Assert
            result.Should().BeFailure("Typed Equals returned 'false' on expected equal objects.");
        }

        [TestMethod]
        public void ApplyEqualsOfTMustReturnExpectedResultForClassObjectsWithDifferentEqualsResultAndExpectedEqualFalse()
        {
            // Arrange
            var first = new BikeWithEqualsOfTClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsOfTClassObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyEqualsOfT<BikeWithEqualsOfTClassObject>(first, second, false);

            // Assert
            result.Should().BeSuccess();
        }

        #endregion

        #region Struct

        [TestMethod]
        public void ApplyEqualsOfTMustReturnExpectedResultForStructObjectsWithSameEqualsResultAndExpectedEqualTrue()
        {
            // Arrange
            var first = new BikeWithEqualsOfTStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsOfTStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEqualsOfT<BikeWithEqualsOfTStructObject>(first, second, true);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyEqualsOfTMustReturnExpectedResultForStructObjectsWithSameEqualsResultAndExpectedEqualFalse()
        {
            // Arrange
            var first = new BikeWithEqualsOfTStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsOfTStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEqualsOfT<BikeWithEqualsOfTStructObject>(first, second, false);

            // Assert
            result.Should().BeFailure("Typed Equals returned 'true' on expected non-equal objects.");
        }

        [TestMethod]
        public void ApplyEqualsOfTMustReturnExpectedResultForStructObjectsWithDifferentEqualsResultAndExpectedEqualTrue()
        {
            // Arrange
            var first = new BikeWithEqualsOfTStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsOfTStructObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyEqualsOfT<BikeWithEqualsOfTStructObject>(first, second, true);

            // Assert
            result.Should().BeFailure("Typed Equals returned 'false' on expected equal objects.");
        }

        [TestMethod]
        public void ApplyEqualsOfTMustReturnExpectedResultForStructObjectsWithDifferentEqualsResultAndExpectedEqualFalse()
        {
            // Arrange
            var first = new BikeWithEqualsOfTStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsOfTStructObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyEqualsOfT<BikeWithEqualsOfTStructObject>(first, second, false);

            // Assert
            result.Should().BeSuccess();
        }

        #endregion
    }
}
