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
                }
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

        #region Linq

        [TestMethod]
        public void LinqExpressionSingleFromClauseShouldSucceed()
        {
            // Arrange
            var expectedResult = Some(1);

            // Act
            var result = from a in Some(1)
                         select a;

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void LinqExpressionTwoFromClausesShouldSucceed()
        {
            // Arrange
            var expectedResult = Some(3);

            // Act
            var result = from a in Some(1)
                         from b in Some(2)
                         select a + b;

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void LinqExpressionThreeFromClausesShouldSucceed()
        {
            // Arrange
            var expectedResult = Some(6);

            // Act
            var result = from a in Some(1)
                         from b in Some(2)
                         from c in Some(3)
                         select a + b + c;

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void LinqExpressionMultipleFromClausesShouldSucceed()
        {
            // Arrange
            var expectedResult = Some(10);

            // Act
            var result = from a in Some(1)
                         from b in Some(2)
                         from c in Some(3)
                         let sum = a + b + c
                         from d in Some(sum)
                         from e in Some(4)
                         select d + e;

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void LinqExpressionFromWhereShouldReturnSome()
        {
            // Arrange
            var expectedResult = Some(1);

            // Act
            var result = from a in Some(1)
                         where a > 0
                         select a;

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void LinqExpressionFromWhereShouldReturnNone()
        {
            // Arrange
            var expectedResult = None;

            // Act
            var result = from a in Some(1)
                         where a > 1
                         select a;

            // Assert
            result.Should().Be(expectedResult);
        }

        #endregion
    }
}
