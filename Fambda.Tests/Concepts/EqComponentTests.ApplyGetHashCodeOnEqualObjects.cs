using Fambda.Tests.Concepts.Objects;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Concepts
{
    public partial class EqComponentTests
    {
        [TestMethod]
        public void ApplyGetHashCodeOnEqualObjectsMustReturnExpectedResultForClassObjectsWithSameHashCode()
        {
            // Arrange
            var first = new BikeWithHashCodeClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithHashCodeClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyGetHashCodeOnEqualObjects<BikeWithHashCodeClassObject>(first, second);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyGetHashCodeOnEqualObjectsMustReturnExpectedResultForClassObjectsWithDifferentHashCode()
        {
            // Arrange
            var first = new BikeWithHashCodeClassObject("Giant", "Revolt", 2020);
            var second = new BikeWithHashCodeClassObject("Giant", "Liv", 2020);

            // Act
            var result = EqComponent.ApplyGetHashCodeOnEqualObjects<BikeWithHashCodeClassObject>(first, second);

            // Assert
            result.Should().BeFailure("GetHashCode of equal objects returned different values.");
        }

        [TestMethod]
        public void ApplyGetHashCodeOnEqualObjectsMustReturnExpectedResultForStructObjectsWithSameHashCode()
        {
            // Arrange
            var first = new BikeWithHashCodeStructObject("Giant", "Revolt", 2020);
            var second = new BikeWithHashCodeStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyGetHashCodeOnEqualObjects<BikeWithHashCodeStructObject>(first, second);

            // Assert
            result.Should().BeSuccess();
        }

        [TestMethod]
        public void ApplyGetHashCodeOnEqualObjectsMustReturnExpectedResultForStructObjectsWithDifferentHashCode()
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