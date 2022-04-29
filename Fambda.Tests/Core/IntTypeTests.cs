using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public class IntTypeTests
    {
        #region Parse

        [Fact]
        public void Parse_ReturnsOptionIntNone()
        {
            // Arrange
            var s = "not an int";
            Option<int> expected = None;

            // Act
            var result = IntType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_ReturnsOptionIntSome()
        {
            // Arrange
            var s = "1";
            Option<int> expected = Some(1);

            // Act
            var result = IntType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStyles_ReturnOptionIntNone()
        {
            // Arrange
            var s = "not an int";
            Option<int> expected = None;

            // Act
            var result = IntType.Parse(s, NumberStyles.Integer);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStyles_ReturnsOptionIntSome()
        {
            // Arrange
            var s = "1";
            Option<int> expected = Some(1);

            // Act
            var result = IntType.Parse(s, NumberStyles.Integer);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStylesWhenStringIsNotExpectedHexNumber_ReturnsOptionIntNone()
        {
            // Arrange
            var s = "1.0";
            Option<int> expected = None;

            // Act
            var result = IntType.Parse(s, NumberStyles.HexNumber);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithFormatProvider_ReturnsOptionIntNone()
        {
            // Arrange
            var s = "positive1234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<int> expected = None;

            // Act
            var result = IntType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithFormatProvider_ReturnsOptionIntSome()
        {
            // Arrange
            var s = "p1234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<int> expected = Some(1234);

            // Act
            var result = IntType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStylesAndFormatProvider_ReturnsOptionIntNone()
        {
            // Arrange
            var s = "p1$234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<int> expected = None;

            // Act
            var result = IntType.Parse(s, NumberStyles.Integer, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStylesAndFormatProvider_ReturnsOptionIntSome()
        {
            // Arrange
            var s = "p1";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<int> expected = Some(1);

            // Act
            var result = IntType.Parse(s, NumberStyles.Integer, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
