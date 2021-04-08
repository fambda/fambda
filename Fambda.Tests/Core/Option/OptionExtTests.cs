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

        #region Bind

        [TestMethod]
        public void BindShouldReturnSome()
        {
            // Arrange
            var value = 1;
            Option<int> option = Some(value);

            Func<int, Option<bool>> toTrueBoolWhenOptionIntOne = (i) =>
            {
                if (i.Equals(1))
                {
                    return Some(true);
                }
                else
                {
                    return None;
                };
            };

            // Act
            var result = option.Bind(toTrueBoolWhenOptionIntOne);


            // Assert
            result.Should().Be(Some(true));
        }

        [TestMethod]
        public void BindShouldReturnNone()
        {
            // Arrange
            Option<int> option = None;

            Func<int, Option<bool>> toTrueBoolWhenOptionIntOne = (i) =>
            {
                if (i.Equals(1))
                {
                    return Some(true);
                }
                else
                {
                    return None;
                };
            };

            // Act
            var result = option.Bind(toTrueBoolWhenOptionIntOne);


            // Assert
            result.Should().Be(None);
        }

        #endregion
    }
}
