using System.Globalization;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public class LongTypeTests
    {
        #region Parse

        [Fact]
        public void Parse_ReturnsOptionLongNone()
        {
            // Arrange
            const string s = "not a long";
            Option<long> expected = None;

            // Act
            var result = LongType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_ReturnsOptionLongSome()
        {
            // Arrange
            const string s = "1";
            Option<long> expected = Some(1L);

            // Act
            var result = LongType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStyles_ReturnsOptionLongNone()
        {
            // Arrange
            const string s = "not a long";
            Option<long> expected = None;

            // Act
            var result = LongType.Parse(s, NumberStyles.Integer);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStyles_ReturnOptionLongSome()
        {
            // Arrange
            const string s = "1";
            Option<long> expected = Some(1L);

            // Act
            var result = LongType.Parse(s, NumberStyles.Number);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStylesWhenStringIsNotExpectedHexNumber_ReturnsOptionLongNone()
        {
            // Arrange
            const string s = "1.0";
            Option<long> expected = None;

            // Act
            var result = LongType.Parse(s, NumberStyles.HexNumber);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithFormatProvider_ReturnsOptionLongNone()
        {
            // Arrange
            const string s = "positive1234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<long> expected = None;

            // Act
            var result = LongType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithFormatProvider_ReturnsOptionLongSome()
        {
            // Arrange
            const string s = "p1234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<long> expected = Some(1234L);

            // Act
            var result = LongType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStylesAndFormatProvider_ReturnsOptionLongNone()
        {
            // Arrange
            const string s = "p1$234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<long> expected = None;

            // Act
            var result = LongType.Parse(s, NumberStyles.Integer, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WithNumberStylesAndFormatProvider_ReturnsOptionLongSome()
        {
            // Arrange
            const string s = "p1";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<long> expected = Some(1L);

            // Act
            var result = LongType.Parse(s, NumberStyles.Integer, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
