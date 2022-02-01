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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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
