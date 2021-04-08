using System;
using System.Globalization;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class FloatTypeTests
    {
        #region Parse

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        #endregion
    }
}
