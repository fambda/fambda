using Fambda.Concepts.Objects;
using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda.Concepts
{
    public class EquableTests
    {
        [Fact]
        public void NullMustSucceed()
        {
            // Arrange
            var obj = new BikeClassObject("Giant", "Revolt", 2020);

            // Act
            var result = new Equable().Null(obj);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        public void EqualMustSucceed()
        {
            // Arrange
            var first = new BikeClassObject("Giant", "Revolt", 2020);
            var second = new BikeClassObject("Giant", "Revolt", 2020);

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        public void UnequalMustSucceed()
        {
            // Arrange
            var first = new BikeClassObject("Giant", "Revolt", 2020);
            var second = new BikeClassObject("Giant", "Touran", 2020);

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }
    }
}
