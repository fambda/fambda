using Fambda.Concepts.Objects;
using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda.Concepts
{
    public partial class EqComponentTests
    {
        #region Class

        [Fact]
        public void ApplyOperatorInequality_ForClassObjectsThatAreActuallyUnequalFalseAndExpectedUnequalTrue_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityClassObject>(first, second, true);

            // Assert
            result.Should().BeFailure("Inequality operator returned 'false' on expected non-equal objects.");
        }

        [Fact]
        public void ApplyOperatorInequality_ForClassObjectsThatAreActuallyUnequalFalseAndExpectedUnequalFalse_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityClassObject>(first, second, false);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyOperatorInequality_ForClassObjectsThatAreActuallyUnequalTrueAndExpectedUnequalTrue_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityClassObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityClassObject>(first, second, true);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyOperatorInequality_ForClassObjectsThatAreActuallyUnequalTrueAndExpectedUnequalFalse_ReturnsExpectedResult()
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

        [Fact]
        public void ApplyOperatorInequality_ForStructObjectsThatAreActuallyUnequalFalseAndExpectedUnequalTrue_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityStructObject>(first, second, true);

            // Assert
            result.Should().BeFailure("Inequality operator returned 'false' on expected non-equal objects.");
        }

        [Fact]
        public void ApplyOperatorInequality_ForStructObjectsThatAreActuallyUnequalFalseAndExpectedUnequalFalse_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityStructObject>(first, second, false);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyOperatorInequality_ForStructObjectsThatAreActuallyUnequalTrueAndExpectedUnequalTrue_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityStructObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequality<BikeOperatorEqualityStructObject>(first, second, true);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyOperatorInequality_ForStructObjectsThatAreActuallyUnequalTrueAndExpectedUnequalFalse_ReturnsExpectedResult()
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
