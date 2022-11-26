using FluentAssertions;
using Xunit;

namespace Fambda
{
    public class FuncExtTests
    {
        #region Apply

        [Fact]
        public void Apply_BinaryFuncToTheFirstArgument_Succeeds()
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
        public void Apply_TernaryFuncToTheFirstArgument_Succeeds()
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
        public void Apply_TernaryFuncToTheFirstTwoArguments_Succeeds()
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
        public void Apply_QuaternaryFuncToTheFirstArgument_Succeeds()
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
        public void Apply_QuaternaryFuncToTheFirstTwoArguments_Succeeds()
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
        public void Apply_QuaternaryFuncToTheFirstThreeArguments_Succeeds()
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
        public void Compose_2Func_Succeeds()
        {
            // Arrange
            Func<int, string> g = x => $"{x * 2}";
            Func<bool, int> f = x => x ? 1 : 0;

            Func<bool, string> expectedFuncComposition = x => g(f(x));
            var expectedValue = "2";

            // Act
            var actualFuncComposition = g.Compose(f);

            var result = actualFuncComposition(true).Equals(expectedFuncComposition(true));
            var actualValue = actualFuncComposition(true);

            // Assert
            result.Should().BeTrue();
            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void Compose_3Func_Succeeds()
        {
            // Arrange
            Func<string, char> h = x => x == "2" ? '+' : '-';
            Func<int, string> g = x => $"{x * 2}";
            Func<bool, int> f = x => x ? 1 : 0;

            Func<bool, char> expectedFuncComposition = x => h(g(f(x)));
            var expectedValue = '+';

            // Act
            var actualFuncComposition = h.Compose(g).Compose(f);

            var result = actualFuncComposition(true).Equals(expectedFuncComposition(true));
            var actualValue = actualFuncComposition(true);

            // Assert
            result.Should().BeTrue();
            actualValue.Should().Be(expectedValue);
        }

        #endregion
    }
}
