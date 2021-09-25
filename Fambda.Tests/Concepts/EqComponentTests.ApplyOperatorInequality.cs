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
        public void ApplyOperatorInequalityMustReturnExpectedResultForClassObjectsThatAreActuallyUnequalFalseAndExpectedUnequalTrue()
        {
            // Arrange
            var first = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityClassObject>(first, second, true);

            // Assert
            result.Should().BeFailure("Inequality operator returned 'false' on expected non-equal objects.");
        }

        [TestMethod]
        public void ApplyOperatorInequalityMustReturnExpectedResultForClassObjectsThatAreActuallyUnequalFalseAndExpectedUnequalFalse()
        {
            // Arrange
            var first = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityClassObject>(first, second, false);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyOperatorInequalityMustReturnExpectedResultForClassObjectsThatAreActuallyUnequalTrueAndExpectedUnequalTrue()
        {
            // Arrange
            var first = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityClassObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityClassObject>(first, second, true);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyOperatorInequalityMustReturnExpectedResultForClassObjectsThatAreActuallyUnequalTrueAndExpectedUnequalFalse()
        {
            // Arrange
            var first = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityClassObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityClassObject>(first, second, false);

            // Assert
            result.Should().BeFailure("Inequality operator returned 'true' on expected equal objects.");
        }

        #endregion

        #region Struct

        [TestMethod]
        public void ApplyOperatorInequalityMustReturnExpectedResultForStructObjectsThatAreActuallyUnequalFalseAndExpectedUnequalTrue()
        {
            // Arrange
            var first = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityStructObject>(first, second, true);

            // Assert
            result.Should().BeFailure("Inequality operator returned 'false' on expected non-equal objects.");
        }

        [TestMethod]
        public void ApplyOperatorInequalityMustReturnExpectedResultForStructObjectsThatAreActuallyUnequalFalseAndExpectedUnequalFalse()
        {
            // Arrange
            var first = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityStructObject>(first, second, false);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyOperatorInequalityMustReturnExpectedResultForStructObjectsThatAreActuallyUnequalTrueAndExpectedUnequalTrue()
        {
            // Arrange
            var first = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityStructObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityStructObject>(first, second, true);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyOperatorInequalityMustReturnExpectedResultForStructObjectsThatAreActuallyUnequalTrueAndExpectedUnequalFalse()
        {
            // Arrange
            var first = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityStructObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityStructObject>(first, second, false);

            // Assert
            result.Should().BeFailure("Inequality operator returned 'true' on expected equal objects.");
        }

        #endregion
    }
}
