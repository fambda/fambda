using System.Globalization;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public class DecimalTypeTests
    {
        #region Parse

        [Fact]
        public void Parse_ReturnsOptionDecimalNone()
        {
            // Arrange
            const string s = "not a decimal";
            Option<decimal> expected = None;

            // Act
            var result = DecimalType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_ReturnsOptionDecimalSome()
        {
            // Arrange
            const string s = "1";
            Option<decimal> expected = Some(1M);

            // Act
            var result = DecimalType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStyles_ReturnsOptionDecimalNone()
        {
            // Arrange
            const string s = "not a decimal";
            Option<decimal> expected = None;

            // Act
            var result = DecimalType.Parse(s, NumberStyles.AllowDecimalPoint);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStyles_ReturnsOptionDecimalSome()
        {
            // Arrange
            const string s = "1.1";
            Option<decimal> expected = Some(1.1M);

            // Act
            var result = DecimalType.Parse(s, NumberStyles.AllowDecimalPoint);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStylesWhenStringIsNotExpectedHexNumber_ReturnsOptionDecimalNone()
        {
            // Arrange
            const string s = "1.1";
            Option<decimal> expected = None;

            // Act
            var result = DecimalType.Parse(s, NumberStyles.HexNumber);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithFormatProvider_ReturnsOptionDecimalNone()
        {
            // Arrange
            const string s = "positive1234.1";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<decimal> expected = None;

            // Act
            var result = DecimalType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithFormatProvider_ReturnsOptionDecimalSome()
        {
            // Arrange
            const string s = "p1234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<decimal> expected = Some(1234M);

            // Act
            var result = DecimalType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStylesAndFormatProvider_ReturnsOptionDecimalNone()
        {
            // Arrange
            const string s = "p1$234.4";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<decimal> expected = None;

            // Act
            var result = DecimalType.Parse(s, NumberStyles.AllowDecimalPoint, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStylesAndFormatProvider_ReturnsOptionDecimalSome()
        {
            // Arrange
            const string s = "p1.1";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p", NumberDecimalSeparator = "." };
            Option<decimal> expected = Some(1.1M);

            // Act
            var result = DecimalType.Parse(s, NumberStyles.Number, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
