using System;
using Fambda.Helpers;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class UnitTests
    {
        [Fact]
        public void GetHashCode_ReturnsZero()
        {
            // Arrange
            var unit = new Unit();

            // Act
            var result = unit.GetHashCode();

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void ToString_ReturnsOpenCloseParantheses()
        {
            // Arrange
            var unit = new Unit();

            // Act
            var result = unit.ToString();

            // Assert
            result.Should().Be("()");
        }

        [Fact]
        public void Operator_GreaterThan_ReturnsFalse()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first > second;

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Operator_GreaterThanOrEqual_ReturnsTrue()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first >= second;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Operator_LessThan_ReturnsFalse()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first < second;

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Operator_LessThanOrEqual_ReturnsTrue()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first <= second;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void CompareTo_ReturnsZero()
        {
            // Arrange
            var expected = 0;
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first.CompareTo(second);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Operator_Addition_ReturnsUnit()
        {
            // Arrange
            var expected = new Unit();
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first + second;

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Operator_Subtraction_ReturnsUnit()
        {
            // Arrange
            var expected = new Unit();
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first - second;

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ImplicitConversion_UnitToValueTuple_ReturnsDefaultValueTuple()
        {
            // Arrange
            ValueTuple expected = default;
            var unit = new Unit();

            // Act
            ValueTuple result = unit;

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ImplicitConversion_ValueTupleToUnit_ReturnsUnit()
        {
            // Arrange
            var expected = new Unit();
            ValueTuple valueTuple = default;

            // Act
            Unit result = valueTuple;

            // Assert
            result.Should().Be(expected);
        }
    }
}
