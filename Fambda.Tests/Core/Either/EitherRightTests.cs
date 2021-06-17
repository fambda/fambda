using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public class EitherRightTests
    {
        [TestMethod]
        public void CtorShouldSucceed()
        {
            // Arrange
            var value = "right";

            // Act
            Action ctor = () => { new EitherRight<string>(value); };

            // Assert
            ctor.Should().NotThrow();
        }

        [TestMethod]
        public void CtorShouldSetCorrectValue()
        {
            // Arrange
            var value = "right";
            var eitherRight = new EitherRight<string>(value);

            // Act
            var result = eitherRight.Value;

            // Assert
            result.Should().Be(value);
        }

        [TestMethod]
        public void ToStringShouldProvideExpectedRepresentation()
        {
            // Arrange
            var value = "right";
            var expectedResult = $"Right({value})";
            var eitherRight = new EitherRight<string>(value);

            // Act
            var result = eitherRight.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
