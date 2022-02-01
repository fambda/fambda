using System;
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
        public void ParseShouldReturnOptionLongNone()
        {
            // Arrange
            var s = "not a long";
            Option<long> expected = None;

            // Act
            var result = LongType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseShouldReturnOptionLongSome()
        {
            // Arrange
            var s = "1";
            Option<long> expected = Some(1L);

            // Act
            var result = LongType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesShouldReturnOptionLongNone()
        {
            // Arrange
            var s = "not a long";
            Option<long> expected = None;

            // Act
            var result = LongType.Parse(s, NumberStyles.Integer);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesShouldReturnOptionLongSome()
        {
            // Arrange
            var s = "1";
            Option<long> expected = Some(1L);

            // Act
            var result = LongType.Parse(s, NumberStyles.Number);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesShouldReturnOptionLongNoneWhenStringIsNotExpectedHexNumber()
        {
            // Arrange
            var s = "1.0";
            Option<long> expected = None;

            // Act
            var result = LongType.Parse(s, NumberStyles.HexNumber);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithFormatProviderShouldReturnOptionLongNone()
        {
            // Arrange
            var s = "positive1234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<long> expected = None;

            // Act
            var result = LongType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithFormatProviderShouldReturnOptionLongSome()
        {
            // Arrange
            var s = "p1234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<long> expected = Some(1234L);

            // Act
            var result = LongType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesAndFormatProviderShouldReturnOptionLongNone()
        {
            // Arrange
            var s = "p1$234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<long> expected = None;

            // Act
            var result = LongType.Parse(s, NumberStyles.Integer, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesAndFormatProviderShouldReturnOptionLongSome()
        {
            // Arrange
            var s = "p1";
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
