using Fambda.Tests.DataTypes;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    public partial class ExceptionalTests
    {
        [TestMethod]
        [TestCategory("Equable")]
        public void EquableNullMustPassWhenSuccess()
        {
            // Arrange
            var value = "any value of any type besides Exception";
            Exceptional<string> exceptional = value;

            // Act
            var result = new Equable().Null(exceptional);

            // Assert
            result.Should().Pass();
        }

        [TestMethod]
        [TestCategory("Equable")]
        public void EquableNullMustPassWhenException()
        {
            // Arrange
            var exception = new SomeException();
            Exceptional<string> exceptional = exception;

            // Act
            var result = new Equable().Null(exceptional);

            // Assert
            result.Should().Pass();
        }

        [TestMethod]
        [TestCategory("Equable")]
        public void EquableEqualMustPassWhenBothSuccess()
        {
            // Arrange
            var firstValue = "any value of any type besides Exception";
            Exceptional<string> first = firstValue;

            var secondValue = "any value of any type besides Exception";
            Exceptional<string> second = secondValue;

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [TestMethod]
        [TestCategory("Equable")]
        public void EquableEqualMustPassWhenBothException()
        {
            // Arrange
            var firstException = new SomeException();
            Exceptional<string> first = firstException;

            var secondException = new SomeException();
            Exceptional<string> second = secondException;

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [TestMethod]
        [TestCategory("Equable")]
        public void EquableUnequalMustPassWhenFirstSuccessAndSecondException()
        {
            // Arrange
            var value = "any value of any type besides Exception";
            Exceptional<string> first = value;

            var secondException = new SomeException();
            Exceptional<string> second = secondException;

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }

        [TestMethod]
        [TestCategory("Equable")]
        public void EquableUnequalMustPassWhenFirstExceptionAndSecondSuccess()
        {
            // Arrange
            var firstException = new SomeException();
            Exceptional<string> first = firstException;

            var value = "any value of any type besides Exception";
            Exceptional<string> second = value;

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }
    }
}
