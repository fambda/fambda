using System;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public class FuncExtTests
    {
        #region Apply

        [Fact]
        public void ApplyBinaryFunctionToTheFirstArgumentShouldSucceed()
        {
            // Arrange
            var arg1 = 1;
            var arg2 = 2;
            Func<int, int, int> add2Args = (t1, t2) => t1 + t2;

            // Act
            var needsOneMoreParam = add2Args.Apply(arg1);
            var result = needsOneMoreParam(arg2);

            // Assert
            result.Should().Be(arg1 + arg2);
        }

        [Fact]
        public void ApplyTernaryFunctionToTheFirstArgumentShouldSucceed()
        {
            // Arrange
            var arg1 = 1;
            var arg2 = 2;
            var arg3 = 3;
            Func<int, int, int, int> add3Args = (t1, t2, t3) => t1 + t2 + t3;

            // Act
            var needsTwoMoreParam = add3Args.Apply(arg1);
            var result = needsTwoMoreParam(arg2, arg3);

            // Assert
            result.Should().Be(arg1 + arg2 + arg3);
        }

        [Fact]
        public void ApplyTernaryFunctionToTheFirstTwoArgumentsShouldSucceed()
        {
            // Arrange
            var arg1 = 1;
            var arg2 = 2;
            var arg3 = 3;
            Func<int, int, int, int> add3Args = (t1, t2, t3) => t1 + t2 + t3;

            // Act
            var needsOneMoreParam = add3Args.Apply(arg1, arg2);
            var result = needsOneMoreParam(arg3);

            // Assert
            result.Should().Be(arg1 + arg2 + arg3);
        }

        [Fact]
        public void ApplyQuaternaryFunctionToTheFirstArgumentShouldSucceed()
        {
            // Arrange
            var arg1 = 1;
            var arg2 = 2;
            var arg3 = 3;
            var arg4 = 3;
            Func<int, int, int, int, int> add4Args = (t1, t2, t3, t4) => t1 + t2 + t3 + t4;

            // Act
            var needsThreeMoreParam = add4Args.Apply(arg1);
            var result = needsThreeMoreParam(arg2, arg3, arg4);

            // Assert
            result.Should().Be(arg1 + arg2 + arg3 + arg4);
        }

        [Fact]
        public void ApplyQuaternaryFunctionToTheFirstTwoArgumentsShouldSucceed()
        {
            // Arrange
            var arg1 = 1;
            var arg2 = 2;
            var arg3 = 3;
            var arg4 = 3;
            Func<int, int, int, int, int> add4Args = (t1, t2, t3, t4) => t1 + t2 + t3 + t4;

            // Act
            var needsTwoMoreParam = add4Args.Apply(arg1, arg2);
            var result = needsTwoMoreParam(arg3, arg4);

            // Assert
            result.Should().Be(arg1 + arg2 + arg3 + arg4);
        }

        [Fact]
        public void ApplyQuaternaryFunctionToTheFirstThreeArgumentsShouldSucceed()
        {
            // Arrange
            var arg1 = 1;
            var arg2 = 2;
            var arg3 = 3;
            var arg4 = 3;
            Func<int, int, int, int, int> add4Args = (t1, t2, t3, t4) => t1 + t2 + t3 + t4;

            // Act
            var needsOneMoreParam = add4Args.Apply(arg1, arg2, arg3);
            var result = needsOneMoreParam(arg4);

            // Assert
            result.Should().Be(arg1 + arg2 + arg3 + arg4);
        }

        #endregion

        #region Compose

        [Fact]
        public void Compose_Succeeds()
        {
            // Arrange
            Func<int, int> f = x => x + 1;
            Func<int, int> g = x => x * 2;
            Func<int, int> expected = x => g(f(x));

            // Act
            var composedFunc = g.Compose(f);
            var result = composedFunc(5).Equals(expected(5));

            // Assert
            result.Should().BeTrue();
        }

        #endregion
    }
}
