using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public class EitherLeftTests
    {
        [TestMethod]
        public void CtorShouldSucceed()
        {
            // Arrange
            var value = "left";

            // Act
            Action ctor = () => { new EitherLeft<string>(value); };

            // Assert
            ctor.Should().NotThrow();
        }

        [TestMethod]
        public void CtorShouldSetCorrectValue()
        {
            // Arrange
            var value = "left";
            var eitherLeft = new EitherLeft<string>(value);

            // Act
            var result = eitherLeft.Value;

            // Assert
            result.Should().Be(value);
        }

        [TestMethod]
        public void EqualsObjectShouldReturnTrueWhenBothValueSameNotNull()
        {
            // Arrange
            var first = new EitherLeft<string>("value");
            var second = new EitherLeft<string>("value");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void EqualsObjectShouldReturnTrueWhenBothValueNull()
        {
            // Arrange
            var first = new EitherLeft<string>(null);
            var second = new EitherLeft<string>(null);

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void EqualsObjectShouldReturnFalseWhenSameTypeAndDifferentValues()
        {
            // Arrange
            var first = new EitherLeft<string>("value1");
            var second = new EitherLeft<string>("value2");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsObjectShouldReturnFalseWhenDifferentTypes()
        {
            // Arrange
            var first = new EitherLeft<string>("1");
            var second = new EitherLeft<int>(1);

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsObjectShouldReturnFalseWhenFirstValueNull()
        {
            // Arrange
            var first = new EitherLeft<string>(null);
            var second = new EitherLeft<string>("value");

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsObjectShouldReturnFalseWhenSecondValueNull()
        {
            // Arrange
            var first = new EitherLeft<string>("value");
            var second = new EitherLeft<string>(null);

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsEitherLeftShouldReturnTrueWhenBothValueSameNotNull()
        {
            // Arrange
            var first = new EitherLeft<string>("value");
            var second = new EitherLeft<string>("value");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void EqualsEitherLeftShouldReturnTrueWhenBothValueNull()
        {
            // Arrange
            var first = new EitherLeft<string>(null);
            var second = new EitherLeft<string>(null);

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void EqualsEitherLeftShouldReturnFalse()
        {
            // Arrange
            var first = new EitherLeft<string>("value1");
            var second = new EitherLeft<string>("value2");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsEitherLeftShouldReturnFalseWhenFirstValueNull()
        {
            // Arrange
            var first = new EitherLeft<string>(null);
            var second = new EitherLeft<string>("value");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsEitherLeftShouldReturnFalseWhenSecondValueNull()
        {
            // Arrange
            var first = new EitherLeft<string>("value");
            var second = new EitherLeft<string>(null);

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
        }


        [TestMethod]
        public void ToStringShouldProvideExpectedRepresentation()
        {
            // Arrange
            var value = "left";
            var expectedResult = $"Left({value})";
            var eitherLeft = new EitherLeft<string>(value);

            // Act
            var result = eitherLeft.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
