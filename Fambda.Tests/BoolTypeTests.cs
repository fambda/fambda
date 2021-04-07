using System;
using System.Globalization;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class BoolTypeTests
    {
        #region Parse

        [DataTestMethod]
        [DataRow("True", true)]
        [DataRow("true", true)]
        [DataRow("tRue", true)]
        [DataRow("False", false)]
        [DataRow("false", false)]
        [DataRow("fAlse", false)]
        public void ParseShouldReturnOptionBoolSome(string str, bool expectedBool)
        {
            // Arrange
            var value = str;
            Option<bool> expected = Some(expectedBool);

            // Act
            var result = BoolType.Parse(value);

            // Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void ParseShouldReturnOptionBoolNone()
        {
            // Arrange
            var value = "not an logical boolean";
            Option<bool> expected = None;

            // Act
            var result = BoolType.Parse(value);

            // Assert
            result.Should().Be(expected);
        }

      
        #endregion
    }
}
