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
        public void ApplyEqualsOfT_ForClassObjectsWithSameEqualsResultAndExpectedEqualTrue_ReturnsExpectedResult()
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
        public void ApplyEqualsOfT_ForClassObjectsWithSameEqualsResultAndExpectedEqualFalse_ReturnsExpectedResult()
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
        public void ApplyEqualsOfT_ForClassObjectsWithDifferentEqualsResultAndExpectedEqualTrue_ReturnsExpectedResult()
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
        public void ApplyEqualsOfT_ForClassObjectsWithDifferentEqualsResultAndExpectedEqualFalse_ReturnsExpectedResult()
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
        public void ApplyEqualsOfT_ForStructObjectsWithSameEqualsResultAndExpectedEqualTrue_ReturnsExpectedResult()
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
        public void ApplyEqualsOfT_ForStructObjectsWithSameEqualsResultAndExpectedEqualFalse_ReturnsExpectedResult()
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
        public void ApplyEqualsOfT_ForStructObjectsWithDifferentEqualsResultAndExpectedEqualTrue_ReturnsExpectedResult()
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
        public void ApplyEqualsOfT_ForStructObjectsWithDifferentEqualsResultAndExpectedEqualFalse_ReturnsExpectedResult()
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
