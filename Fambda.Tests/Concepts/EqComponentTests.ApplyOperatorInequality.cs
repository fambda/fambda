using Fambda.Tests.Concepts.Objects;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests.Concepts
{
    public partial class EqComponentTests
    {
        #region Class

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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
