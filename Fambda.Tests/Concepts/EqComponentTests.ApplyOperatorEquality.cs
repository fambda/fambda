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
        public void ApplyOperatorEqualityMustReturnExpectedResultForClassObjectsWithSameEqualsResultAndExpectedEqualTrue()
        {
            // Arrange
            var first = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEquality<BikeOperatorEqualityClassObject>(first, second, true);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyOperatorEqualityMustReturnExpectedResultForClassObjectsWithSameEqualsResultAndExpectedEqualFalse()
        {
            // Arrange
            var first = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEquality<BikeOperatorEqualityClassObject>(first, second, false);

            // Assert
            result.Should().BeFailure("Equality operator returned 'true' on expected non-equal objects.");
        }

        [Fact]
        public void ApplyOperatorEqualityMustReturnExpectedResultForClassObjectsWithDifferentEqualsResultAndExpectedEqualTrue()
        {
            // Arrange
            var first = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityClassObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEquality<BikeOperatorEqualityClassObject>(first, second, true);

            // Assert
            result.Should().BeFailure("Equality operator returned 'false' on expected equal objects.");
        }

        [Fact]
        public void ApplyOperatorEqualityMustReturnExpectedResultForClassObjectsWithDifferentEqualsResultAndExpectedEqualFalse()
        {
            // Arrange
            var first = new BikeOperatorEqualityClassObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityClassObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEquality<BikeOperatorEqualityClassObject>(first, second, false);

            // Assert
            result.Should().BeSuccess();
        }

        #endregion

        #region Struct

        [Fact]
        public void ApplyOperatorEqualityMustReturnExpectedResultForStructObjectsWithSameEqualsResultAndExpectedEqualTrue()
        {
            // Arrange
            var first = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEquality<BikeOperatorEqualityStructObject>(first, second, true);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyOperatorEqualityMustReturnExpectedResultForStructObjectsWithSameEqualsResultAndExpectedEqualFalse()
        {
            // Arrange
            var first = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEquality<BikeOperatorEqualityStructObject>(first, second, false);

            // Assert
            result.Should().BeFailure("Equality operator returned 'true' on expected non-equal objects.");
        }

        [Fact]
        public void ApplyOperatorEqualityMustReturnExpectedResultForStructObjectsWithDifferentEqualsResultAndExpectedEqualTrue()
        {
            // Arrange
            var first = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityStructObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEquality<BikeOperatorEqualityStructObject>(first, second, true);

            // Assert
            result.Should().BeFailure("Equality operator returned 'false' on expected equal objects.");
        }

        [Fact]
        public void ApplyOperatorEqualityMustReturnExpectedResultForStructObjectsWithDifferentEqualsResultAndExpectedEqualFalse()
        {
            // Arrange
            var first = new BikeOperatorEqualityStructObject("Giant", "Revolt", 2020);
            var second = new BikeOperatorEqualityStructObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyOperatorEquality<BikeOperatorEqualityStructObject>(first, second, false);

            // Assert
            result.Should().BeSuccess();
        }

        #endregion

    }
}
