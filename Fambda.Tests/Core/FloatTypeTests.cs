using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public class FloatTypeTests
    {
        #region Parse

        [Fact]
        public void ParseShouldReturnOptionFloatNone()
        {
            // Arrange
            var s = "not a float";
            Option<float> expected = None;

            // Act
            var result = FloatType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseShouldReturnOptionFloatSome()
        {
            // Arrange
            var s = "1.1";
            Option<float> expected = Some(1.1F);

            // Act
            var result = FloatType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesShouldReturnOptionFloatNone()
        {
            // Arrange
            var s = "not a float";
            Option<float> expected = None;

            // Act
            var result = FloatType.Parse(s, NumberStyles.Number);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesShouldReturnOptionFloatSome()
        {
            // Arrange
            var s = "1.1";
            Option<float> expected = Some(1.1F);

            // Act
            var result = FloatType.Parse(s, NumberStyles.Number);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesShouldReturnOptionFloatNoneWhenStringIsNotExpectedHexNumber()
        {
            // Arrange
            var s = "1.0";
            Option<float> expected = None;

            // Act
            var result = FloatType.Parse(s, NumberStyles.HexNumber);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithFormatProviderShouldReturnOptionFloatNone()
        {
            // Arrange
            var s = "positive1234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<float> expected = None;

            // Act
            var result = FloatType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithFormatProviderShouldReturnOptionFloatSome()
        {
            // Arrange
            var s = "p1234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<float> expected = Some(1234F);

            // Act
            var result = FloatType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesAndFormatProviderShouldReturnOptionFloatNone()
        {
            // Arrange
            var s = "p1$234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<float> expected = None;

            // Act
            var result = FloatType.Parse(s, NumberStyles.Number, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesAndFormatProviderShouldReturnOptionFloatSome()
        {
            // Arrange
            var s = "p1";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<float> expected = Some(1F);

            // Act
            var result = FloatType.Parse(s, NumberStyles.Number, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
