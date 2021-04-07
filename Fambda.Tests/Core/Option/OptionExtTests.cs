using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class OptionExtTests
    {
        #region Map

        [TestMethod]
        public void MapShouldSucceedWhenSome()
        {
            // Arrange
            var value = 1;
            Option<int> option = Some(value);
            Func<int, string> toString = i => i.ToString();

            // Act
            var result = option.Map(toString);

            // Assert
            result.ToString().Should().Be("Some(1)");
        }

        [TestMethod]
        public void MapShouldSucceedWhenNone()
        {
            // Arrange
            Option<int> option = None;
            Func<int, string> toString = i => i.ToString();

            // Act
            var result = option.Map(toString);

            // Assert
            result.ToString().Should().Be("None");
        }

        #endregion
    }
}
