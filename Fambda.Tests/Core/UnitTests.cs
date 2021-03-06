﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void EqualsShouldReturnTrue()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void GetHashCodeShouldReturnZero()
        {
            // Arrange
            var unit = new Unit();

            // Act
            var result = unit.GetHashCode();

            // Assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void ToStringShouldReturnOpenCloseParantheses()
        {
            // Arrange
            var unit = new Unit();

            // Act
            var result = unit.ToString();

            // Assert
            result.Should().Be("()");
        }

        [TestMethod]
        public void UnitsShouldEqual()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void OperatorEqualToOverloadingShouldReturnTrue()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first == second;

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void OperatorNotEqualToOverloadingShouldReturnFalse()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first != second;

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void OperatorGreaterThanOverloadingShouldReturnFalse()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first > second;

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void OperatorGreaterThanOrEqualToOverloadingShouldReturnTrue()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first >= second;

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void OperatorLesserThanOverloadingShouldReturnFalse()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first < second;

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void OperatorLesserThanOrEqualToOverloadingShouldReturnTrue()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first <= second;

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void CompareToShouldReturnZero()
        {
            // Arrange
            var expectedResult = 0;
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first.CompareTo(second);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void OperatorAdditionOverloadingShouldReturnUnit()
        {
            // Arrange
            var expectedResult = new Unit();
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first + second;

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void OperatorSubtractionOverloadingShouldReturnUnit()
        {
            // Arrange
            var expectedResult = new Unit();
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first - second;

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ImplicitUnitToValueTupleConversionShouldReturnDefaultValueTuple()
        {
            // Arrange
            ValueTuple expectedResult = default;
            var unit = new Unit();

            // Act
            ValueTuple result = unit;

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ImplicitValueTupleToUnitConversionShouldReturnUnit()
        {
            // Arrange
            var expectedResult = new Unit();
            ValueTuple valueTuple = default;

            // Act
            Unit result = valueTuple;

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void UnitViaCtorAndViaFShouldEqual()
        {
            // Arrange
            var unit = new Unit();
            var expected = F.Unit();

            // Act
            var result = Equals(unit, expected);

            // Assert
            result.Should().BeTrue();
        }
    }
}
