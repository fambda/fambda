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

        public void EqualsObjectShouldReturnTrueWhenBothValueSameNotNull()
        {
            // Arrange
            var first = new EitherRight<string>("value");
            var second = new EitherRight<string>("value");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void EqualsObjectShouldReturnTrueWhenBothValueNull()
        {
            // Arrange
            var first = new EitherRight<string>(null);
            var second = new EitherRight<string>(null);

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
        }

        public void EqualsObjectShouldReturnFalseWhenSameTypeAndDifferentValues()
        {
            // Arrange
            var first = new EitherRight<string>("value1");
            var second = new EitherRight<string>("value2");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsObjectShouldReturnFalseWhenDifferentTypes()
        {
            // Arrange
            var first = new EitherRight<string>("1");
            var second = new EitherRight<int>(1);

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsObjectShouldReturnFalseWhenFirstValueNull()
        {
            // Arrange
            var first = new EitherRight<string>(null);
            var second = new EitherRight<string>("value");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsObjectShouldReturnFalseWhenSecondValueNull()
        {
            // Arrange
            var first = new EitherRight<string>("value");
            var second = new EitherRight<string>(null);

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsEitherLeftShouldReturnTrueWhenBothValueSameNotNull()
        {
            // Arrange
            var first = new EitherRight<string>("value");
            var second = new EitherRight<string>("value");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void EqualsEitherLeftShouldReturnTrueWhenBothValueNull()
        {
            // Arrange
            var first = new EitherRight<string>(null);
            var second = new EitherRight<string>(null);

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void EqualsEitherRightShouldReturnFalse()
        {
            // Arrange
            var first = new EitherRight<string>("value1");
            var second = new EitherRight<string>("value2");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsEitherLeftShouldReturnFalseWhenFirstValueNull()
        {
            // Arrange
            var first = new EitherRight<string>(null);
            var second = new EitherRight<string>("value");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsEitherLeftShouldReturnFalseWhenSecondValueNull()
        {
            // Arrange
            var first = new EitherRight<string>("value");
            var second = new EitherRight<string>(null);

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
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
