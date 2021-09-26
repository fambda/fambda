using System;
using Fambda.Contracts;
using Fambda.Tests.Concepts.Objects;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Concepts
{
    [TestClass]
    public class EquableTests
    {
        [TestMethod]
        public void NullMustThrow()
        {
            // Arrange
            BikeClassObject obj = null;

            // Act
            Action act = () => { new Equable().Null(obj); };

            // Assert
            act.Should().Throw<EachParamMustNotBeNullException>();
        }

        [TestMethod]
        public void NullMustSucceed()
        {
            // Arrange
            var obj = new BikeClassObject("Giant", "Revolt", 2020);

            // Act
            var result = new Equable().Null(obj);

            // Assert
            result.Should().Pass();
        }


        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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
