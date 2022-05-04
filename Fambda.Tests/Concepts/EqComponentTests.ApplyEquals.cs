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
        public void ApplyEquals_ForClassObjectsWithSameEqualsResultAndExpectedEqualTrue_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeWithEqualsClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsClassObject>(first, second, true);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyEquals_ForClassObjectsWithSameEqualsResultAndExpectedEqualFalse_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeWithEqualsClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsClassObject>(first, second, false);

            // Assert
            result.Should().BeFailure("Equals returned 'true' on expected non-equal objects.");
        }

        [Fact]
        public void ApplyEquals_ForClassObjectsWithDifferentEqualsResultAndExpectedEqualTrue_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeWithEqualsClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsClassObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsClassObject>(first, second, true);

            // Assert
            result.Should().BeFailure("Equals returned 'false' on expected equal objects.");
        }

        [Fact]
        public void ApplyEquals_ForClassObjectsWithDifferentEqualsResultAndExpectedEqualFalse_ReturnsExpectedResult()
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

        [Fact]
        public void ApplyEquals_ForStructObjectsWithSameEqualsResultAndExpectedEqualTrue_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeWithEqualsStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsStructObject>(first, second, true);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyEquals_ForStructObjectsWithSameEqualsResultAndExpectedEqualFalse_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeWithEqualsStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsStructObject>(first, second, false);

            // Assert
            result.Should().BeFailure("Equals returned 'true' on expected non-equal objects.");
        }

        [Fact]
        public void ApplyEquals_ForStructObjectsWithDifferentEqualsResultAndExpectedEqualTrue_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeWithEqualsStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithEqualsStructObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyEquals<BikeWithEqualsStructObject>(first, second, true);

            // Assert
            result.Should().BeFailure("Equals returned 'false' on expected equal objects.");
        }

        [Fact]
        public void ApplyEquals_ForStructObjectsWithDifferentEqualsResultAndExpectedEqualFalse_ReturnsExpectedResult()
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
