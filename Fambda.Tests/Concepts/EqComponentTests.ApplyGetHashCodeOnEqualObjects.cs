using Fambda.Concepts.Objects;
using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda.Concepts
{
    public partial class EqComponentTests
    {
        [Fact]
        public void ApplyGetHashCodeOnEqualObjects_ForClassObjectsWithSameHashCode_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeWithHashCodeClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithHashCodeClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyGetHashCodeOnEqualObjects<BikeWithHashCodeClassObject>(first, second);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyGetHashCodeOnEqualObjects_ForClassObjectsWithDifferentHashCode_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeWithHashCodeClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithHashCodeClassObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyGetHashCodeOnEqualObjects<BikeWithHashCodeClassObject>(first, second);

            // Assert
            result.Should().BeFailure("GetHashCode of equal objects returned different values.");
        }

        [Fact]
        public void ApplyGetHashCodeOnEqualObjects_ForStructObjectsWithSameHashCode_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeWithHashCodeStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithHashCodeStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyGetHashCodeOnEqualObjects<BikeWithHashCodeStructObject>(first, second);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyGetHashCodeOnEqualObjects_ForStructObjectsWithDifferentHashCode_ReturnsExpectedResult()
        {
            // Arrange
            var first = new BikeWithHashCodeStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithHashCodeStructObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyGetHashCodeOnEqualObjects<BikeWithHashCodeStructObject>(first, second);

            // Assert
            result.Should().BeFailure("GetHashCode of equal objects returned different values.");
        }

    }
}
