using System;
using FluentAssertions;
using Xunit;

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
    }
}
