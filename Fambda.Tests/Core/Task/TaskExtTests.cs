using System;
using System.Threading;
using System.Threading.Tasks;
using Fambda.DataTypes;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public class TaskExtTests
    {
        #region Map

        [Fact]
        public async void Map_UnaryFuncOverTaskCompletedSuccessfully_ReturnsExpectedResult()
        {
            // Arrange
            var task = F.TaskSucc(1);
            Func<int, string> toString = i => i.ToString();
            const string expected = "1";

            // Act
            var result = await task.Map(toString);

            // Assert
            result.Should().Be(expected);
        }

        #endregion

        #region Linq

        [Fact]
        public async void Linq_SingleFromClause_Succeeds()
        {
            // Arrange
            var expectedResult = Some(1);

            // Act
            var result = await (
                            from x in TaskSucc(Some(1))
                            select x
                         );

            // Assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public async void Linq_TwoFromClauses_Succeeds()
        {
            // Arrange
            var expectedResult = Some(3);

            // Act
            var result = await (
                             from a in TaskSucc(Some(1))
                             from b in TaskSucc(Some(2))
                             select a.Map(x => x + b.Match(
                                                        None: () => 0,
                                                        Some: (i) => i
                                                    )
                                      )
                         );

            // Assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public async void Linq_ThreeFromClauses_Succeeds()
        {
            // Arrange
            var expectedResult = Some(6);

            // Act
            var result = await (
                             from a in TaskSucc(Some(1))
                             from b in TaskSucc(Some(2))
                             from c in TaskSucc(Some(3))
                             select Some(a.Match(None: () => 0, Some: (i) => i) +
                                         b.Match(None: () => 0, Some: (i) => i) +
                                         c.Match(None: () => 0, Some: (i) => i))
                         );

            // Assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Linq_Exceptions_Succeeds()
        {
            // Arrange
            var task = from x in Task.Factory.StartNew<int>(() => { Thread.Sleep(100); throw new SomeException(); })
                       from y in Task.Factory.StartNew<int>(() => { throw new AnotherException(); })
                       select x + y;

            // Act
            Func<Task> act = async () => { await task; };

            // Assert
            act.Should().ThrowAsync<SomeException>();
        }

        #endregion
    }
}
