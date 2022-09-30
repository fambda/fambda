using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public class OptionExtTests
    {
        #region Map

        [Fact]
        public void Map_UnaryFuncOverNone_ReturnsNone()
        {
            // Arrange
            Option<int> option = None;
            Func<int, string> toString = i => i.ToString();
            var expected = None;

            // Act
            var result = option.Map(toString);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Map_UnaryFuncOverSome_ReturnsSome()
        {
            // Arrange
            var value = 1;
            Option<int> option = Some(value);
            Func<int, string> toString = i => i.ToString();
            var expected = Some("1");

            // Act
            var result = option.Map(toString);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Map_BinaryFuncOverSome_ReturnsNone()
        {
            // Arrange
            Option<int> option = None;
            Func<int, int, string> toString = (i, j) => (i + j).ToString();
            var expected = None;

            // Act
            var result = option.Map(toString);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Map_BinaryFuncOverSome_ReturnsSome()
        {
            // Arrange
            var value = 1;
            Option<int> option = Some(value);
            Func<int, int, string> toString = (i, j) => (i + j).ToString();
            var expected = Some("3");

            // Act
            var result = option.Map(toString).Apply(Some(2));

            // Assert
            result.Should().Be(expected);
        }

        #endregion

        #region Bind

        [Fact]
        public void Bind_ReturnsNone()
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
                }
            };

            var expected = None;

            // Act
            var result = option.Bind(toTrueBoolWhenOptionIntOne);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Bind_ReturnsSome()
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

            var expected = Some(true);

            // Act
            var result = option.Bind(toTrueBoolWhenOptionIntOne);

            // Assert
            result.Should().Be(expected);
        }


        [Fact]
        public async Task Bind_NoneToTaskReturningSome_ReturnsNone()
        {
            // Arrange
            Option<int> option = None;

            Func<int, Task<Option<bool>>> toTrueBoolWhenOptionIntOne = (i) =>
            {
                if (i.Equals(1))
                {
                    return TaskSucc(Some(true));
                }
                else
                {
                    Option<bool> none = None;
                    return TaskSucc(none);
                }
            };

            var expected = None;

            // Act
            var result = await option.Bind(toTrueBoolWhenOptionIntOne);

            // Assert
            result.Should().Be(expected);
        }

        [Fact()]
        public async Task Bind_SomeToTaskReturningNone_ReturnsNone()
        {
            // Arrange
            var value = 2;
            Option<int> option = Some(value);

            Func<int, Task<Option<bool>>> toTrueBoolWhenOptionIntOne = (i) =>
            {
                if (i.Equals(1))
                {
                    return TaskSucc(Some(true));
                }
                else
                {
                    Option<bool> none = None;
                    return TaskSucc(none);
                }
            };

            var expected = None;

            // Act
            var result = await option.Bind(toTrueBoolWhenOptionIntOne);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public async Task Bind_SomeToTaskReturningSome_ReturnsSome()
        {
            // Arrange
            var value = 1;
            Option<int> option = Some(value);

            Func<int, Task<Option<bool>>> toTrueBoolWhenOptionIntOne = (i) =>
            {
                if (i.Equals(1))
                {
                    return TaskSucc(Some(true));
                }
                else
                {
                    Option<bool> none = None;
                    return TaskSucc(none);
                }
            };

            var expected = Some(true);

            // Act
            var result = await option.Bind(toTrueBoolWhenOptionIntOne);

            // Assert
            result.Should().Be(expected);
        }

        #endregion

        #region Apply

        [Fact]
        public void Apply_UnaryFuncToSomeArg_ReturnsNone()
        {
            // Arrange
            var optionArg = None;
            Func<int, string> toArrowString = t => "-> " + t.ToString();
            var expected = None;

            // Act
            var result = Some(toArrowString)
                            .Apply(optionArg);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Apply_UnaryFuncToSomeArg_ReturnsSome()
        {
            // Arrange
            var optionArg = Some(1);
            Func<int, string> toArrowString = t => "-> " + t.ToString();
            var expected = Some("-> 1");

            // Act
            var result = Some(toArrowString)
                            .Apply(optionArg);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Apply_BinaryFuncToFirstArgNone_Succeeds()
        {
            // Arrange
            var optionArg1 = None;
            var optionArg2 = Some(2);
            Func<int, int, int> add2Args = (t1, t2) => t1 + t2;
            var expected = None;

            // Act
            var needsOneMoreParam = Some(add2Args)
                                    .Apply(optionArg1);
            var result = needsOneMoreParam.Apply(optionArg2);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Apply_BinaryFuncToFirstArgSome_Succeeds()
        {
            // Arrange
            var optionArg1 = Some(1);
            var optionArg2 = Some(2);
            Func<int, int, int> add2Args = (t1, t2) => t1 + t2;
            var expected = Some(3);

            // Act
            var needsOneMoreParam = Some(add2Args)
                                    .Apply(optionArg1);
            var result = needsOneMoreParam.Apply(optionArg2);

            // Assert
            result.Should().Be(expected);
        }


        [Fact]
        public void Apply_BinaryFuncToFirstArgNoneAndSecondArgSome_ReturnsNone()
        {
            // Arrange
            var optionArg1 = None;
            var optionArg2 = Some(2);
            Func<int, int, int> add2Args = (t1, t2) => t1 + t2;
            var expected = None;

            // Act
            var result = Some(add2Args)
                            .Apply(optionArg1, optionArg2);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Apply_BinaryFuncToFirstArgSomeAndSecondArgNone_ReturnsNone()
        {
            // Arrange
            var optionArg1 = Some(1);
            var optionArg2 = None;
            Func<int, int, int> add2Args = (t1, t2) => t1 + t2;
            var expected = None;

            // Act
            var result = Some(add2Args)
                            .Apply(optionArg1, optionArg2);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Apply_BinaryFuncToFirstArgSomeAndSecondArgSome_ReturnsSome()
        {
            // Arrange
            var optionArg1 = Some(1);
            var optionArg2 = Some(2);
            Func<int, int, int> add2Args = (t1, t2) => t1 + t2;
            var expected = Some(3);

            // Act
            var result = Some(add2Args)
                            .Apply(optionArg1, optionArg2);

            // Assert
            result.Should().Be(expected);
        }

        #endregion

        #region Linq

        [Fact]
        public void Linq_SingleFromClause_Succeeds()
        {
            // Arrange
            var expectedResult = Some(1);

            // Act
            var result = from a in Some(1)
                         select a;

            // Assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Linq_TwoFromClauses_Succeeds()
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

        [Fact]
        public void Linq_ThreeFromClauses_Succeeds()
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

        [Fact]
        public void Linq_MultipleFromClauses_Succeeds()
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

        [Fact]
        public void Linq_FromWhere_ReturnsNone()
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

        [Fact]
        public void Linq_FromWhere_ReturnsSome()
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

        #endregion

        #region AsEnumerable

        [Fact]
        public void AsEnumerable_OnNone_ReturnsEmptyCollection()
        {
            // Arrange
            Option<int> option = None;
            IEnumerable<int> expected = new List<int>() { };

            // Act
            var result = option.AsEnumerable();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void AsEnumerable_OnSome_ReturnsCollectionWithOneItem()
        {
            // Arrange
            var value = 1;
            Option<int> option = Some(value);
            IEnumerable<int> expected = new List<int>() { 1 };

            // Act
            var result = option.AsEnumerable();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        #endregion
    }
}
