using System;
using Fambda.Contracts;
using Fambda.Tests.Concepts.Objects;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests.Concepts
{
    public class EquableTests
    {
        [Fact]
        public void NullMustThrow()
        {
            // Arrange
            BikeClassObject obj = null;

            // Act
            Action act = () => { new Equable().Null(obj); };

            // Assert
            act.Should().Throw<EachParamMustNotBeNullException>();
        }

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
        public void EqualMustThrowWhenFirstIsNullAndSecondIsNull()
        {
            // Arrange
            BikeClassObject first = null;
            BikeClassObject second = null;

            // Act
            Action act = () => { new Equable().Equal(first, second); };

            // Assert
            act.Should().Throw<EachParamMustNotBeNullException>();
        }

        [Fact]
        public void EqualMustThrowWhenFirstIsNullAndSecondIsNotNull()
        {
            // Arrange
            BikeClassObject first = null;
            var second = new BikeClassObject("Giant", "Revolt", 2020);

            // Act
            Action act = () => { new Equable().Equal(first, second); };

            // Assert
            act.Should().Throw<EachParamMustNotBeNullException>();
        }

        [Fact]
        public void EqualMustThrowWhenFirstIsNotNullAndSecondIsNull()
        {
            // Arrange
            BikeClassObject first = new BikeClassObject("Giant", "Revolt", 2020);
            BikeClassObject second = null;

            // Act
            Action act = () => { new Equable().Equal(first, second); };

            // Assert
            act.Should().Throw<EachParamMustNotBeNullException>();
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
        public void UnequalMustThrowWhenFirstIsNullAndSecondIsNull()
        {
            // Arrange
            BikeClassObject first = null;
            BikeClassObject second = null;

            // Act
            Action act = () => { new Equable().Unequal(first, second); };

            // Assert
            act.Should().Throw<EachParamMustNotBeNullException>();
        }

        [Fact]
        public void UnequalMustThrowWhenFirstIsNullAndSecondIsNotNull()
        {
            // Arrange
            BikeClassObject first = null;
            var second = new BikeClassObject("Giant", "Revolt", 2020);

            // Act
            Action act = () => { new Equable().Unequal(first, second); };

            // Assert
            act.Should().Throw<EachParamMustNotBeNullException>();
        }

        [Fact]
        public void UnequalMustThrowWhenFirstIsNotNullAndSecondIsNull()
        {
            // Arrange
            var first = new BikeClassObject("Giant", "Revolt", 2020);
            BikeClassObject second = null;

            // Act
            Action act = () => { new Equable().Unequal(first, second); };

            // Assert
            act.Should().Throw<EachParamMustNotBeNullException>();
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
