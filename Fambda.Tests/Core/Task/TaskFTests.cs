using Fambda.DataTypes;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public class TaskFTests
    {
        [Fact]
        public void TaskSucc_ReturnsTaskWithRanToCompletionStatus()
        {
            // Arrange
            var task = F.TaskSucc(1);

            // Act
            var result = task.Status == TaskStatus.RanToCompletion;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task TaskSucc_Awaited_ReturnsExpectedValue()
        {
            // Arrange
            var task = F.TaskSucc("value");
            var expected = "value";

            // Act
            var result = await task;

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void TaskFail_ReturnsTaskWithFaultedStatus()
        {
            // Arrange
            var task = F.TaskFail<string>(new SomeException());

            // Act
            var result = task.Status == TaskStatus.Faulted;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void TaskFail_Awaited_ThrowsException()
        {
            // Arrange
            var task = F.TaskFail<string>(new SomeException());

            // Act
            Func<Task> act = async () => { await task; };

            // Assert
            act.Should().ThrowAsync<SomeException>();
        }
    }
}
