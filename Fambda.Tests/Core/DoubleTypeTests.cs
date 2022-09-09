using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public class DoubleTypeTests
    {
        #region Parse

        [Fact]
        public void Parse_ReturnsOptionDoubleNone()
        {
            // Arrange
            const string s = "not a double";
            Option<double> expected = None;

            // Act
            var result = DoubleType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_ReturnsOptionDoubleSome()
        {
            // Arrange
            const string s = "1.1";
            Option<double> expected = Some(1.1);

            // Act
            var result = DoubleType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStyles_ReturnsOptionDoubleNone()
        {
            // Arrange
            const string s = "not a double";
            Option<double> expected = None;

            // Act
            var result = DoubleType.Parse(s, NumberStyles.Number);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStyles_ReturnsOptionDoubleSome()
        {
            // Arrange
            const string s = "1.1";
            Option<double> expected = Some(1.1);

            // Act
            var result = DoubleType.Parse(s, NumberStyles.Number);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStylesWhenStringIsNotExpectedHexNumber_ReturnsOptionDoubleNone()
        {
            // Arrange
            const string s = "1.0";
            Option<double> expected = None;

            // Act
            var result = DoubleType.Parse(s, NumberStyles.HexNumber);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithFormatProvider_ReturnsOptionDoubleNone()
        {
            // Arrange
            const string s = "positive1234.5";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<double> expected = None;

            // Act
            var result = DoubleType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithFormatProvider_ReturnsOptionDoubleSome()
        {
            // Arrange
            const string s = "p1234.5";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<double> expected = Some(1234.5);

            // Act
            var result = DoubleType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStylesAndFormatProvider_ReturnsOptionDoubleNone()
        {
            // Arrange
            const string s = "p1$234.5";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<double> expected = None;

            // Act
            var result = DoubleType.Parse(s, NumberStyles.Number, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStylesAndFormatProvider_ReturnOptionDoubleSome()
        {
            // Arrange
            const string s = "p1.2";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<double> expected = Some(1.2);

            // Act
            var result = DoubleType.Parse(s, NumberStyles.Number, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
