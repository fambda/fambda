using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda.Tests
{
    public class DateTimeTypeTests
    {
        #region Parse

        [Fact]
        public void ParseShouldReturnOptionDateTimeSome()
        {
            // Arrange
            var dateTime = DateTime.Now;
            var s = dateTime.ToString("o", CultureInfo.CurrentCulture);
            Option<DateTime> expected = Some(dateTime);

            // Act
            var result = DateTimeType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseShouldReturnOptionDateTimeNone()
        {
            // Arrange
            var s = "not a date and time";
            Option<DateTime> expected = None;

            // Act
            var result = DateTimeType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }


        [Fact]
        public void ParseWithFormatProviderShouldReturnOptionDateTimeSome()
        {
            // Arrange
            var dateTime = DateTime.Now;
            IFormatProvider formatProvider = CultureInfo.CreateSpecificCulture("de-DE");
            var s = dateTime.ToString("o", formatProvider);
            Option<DateTime> expected = Some(dateTime);

            // Act
            var result = DateTimeType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithFormatProviderShouldReturnOptionDateTimeNone()
        {
            // Arrange
            var s = "2021-06-21 17:35";
            IFormatProvider formatProvider = CultureInfo.CreateSpecificCulture("de-DE");

            Option<int> expected = None;

            // Act
            var result = IntType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
