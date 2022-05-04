using Fambda.Concepts.Objects;
using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda.Concepts
{
    public partial class EqComponentTests
    {
        [Fact]
        public void ApplyInequalityOperatorToNull_ForClassDumbObjectNotNull_ReturnsExpectedResult()
        {
            // Arrange
            var bikeDumbClassObject = new BikeDumbClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequalityToNull<BikeDumbClassObject>(bikeDumbClassObject);

            // Assert
            result.Should().BeFailure("Type does not override inequality operator.");
        }

        [Fact]
        public void ApplyInequalityOperatorToNull_ForClassOperatorObjectNotNull_ReturnsExpectedResult()
        {
            // Arrange
            var bikeOperatorClassObject = new BikeOperatorClassObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequalityToNull<BikeOperatorClassObject>(bikeOperatorClassObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyInequalityOperatorToNull_ForStructDumbObjectDefault_ReturnsExpectedResult()
        {
            // Arrange
            var bikeDumbStructObject = new BikeDumbStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequalityToNull<BikeDumbStructObject>(bikeDumbStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyInequalityOperatorToNull_ForStructOperatorObjectNotDefault_ReturnsExpectedResult()
        {
            // Arrange
            var bikeOperatorStructObject = new BikeOperatorStructObject("Giant", "Revolt", 2020);

            // Act
            var result = EqComponent.ApplyOperatorInequalityToNull<BikeOperatorStructObject>(bikeOperatorStructObject);

            // Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void ApplyInequalityOperatorToNull_ForStructOperatorObjectDefaultNull_ReturnsExpectedResult()
        {
            // Arrange
            BikeOperatorStructObject bikeOperatorStructObject = default;

            // Act
            var result = EqComponent.ApplyOperatorInequalityToNull<BikeOperatorStructObject>(bikeOperatorStructObject);

            // Assert
            result.Should().BeSuccess();
        }
    }
}
