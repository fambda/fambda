using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public class FambdaFTests
    {
        #region Curry
        [TestMethod]
        public void CurryFunctionWithTwoParametersShouldSucceed()
        {
            // Arrange
            Func<int, int, int> add2Args = (t1, t2) => t1 + t2;
            int add2ArgsResult = add2Args(1, 2);

            // Act
            Func<int, Func<int, int>> add2ArgsCurried = F.Curry(add2Args);
            int result = add2ArgsCurried(1)(2);

            // Assert
            result.Should().Be(add2ArgsResult);
        }

        [TestMethod]
        public void CurryFunctionWithThreeParametersShouldSucceed()
        {
            // Arrange
            Func<int, int, int, int> add3Args = (t1, t2, t3) => t1 + t2 + t3;
            int add3ArgsResult = add3Args(1, 2, 3);

            // Act
            Func<int, Func<int, Func<int, int>>> add3ArgsCurried = F.Curry(add3Args);
            int result = add3ArgsCurried(1)(2)(3);

            // Assert
            result.Should().Be(add3ArgsResult);
        }

        [TestMethod]
        public void CurryFunctionWithFourParametersShouldSucceed()
        {
            // Arrange
            Func<int, int, int, int, int> add4Args = (t1, t2, t3, t4) => t1 + t2 + t3 + t4;
            int add4ArgsResult = add4Args(1, 2, 3, 4);

            // Act
            Func<int, Func<int, Func<int, Func<int, int>>>> add4ArgsCurried = F.Curry(add4Args);
            int result = add4ArgsCurried(1)(2)(3)(4);

            // Assert
            result.Should().Be(add4ArgsResult);
        }

        #endregion

        #region Uncurry

        [TestMethod]
        public void UncurryFunctionToTwoParametersShouldSucceed()
        {
            // Arrange
            Func<int, Func<int, int>> add2ArgsCurried = (int t1) => (int t2) => t1 + t2;
            int add2ArgsResult = add2ArgsCurried(1)(2);

            // Act
            Func<int, int, int> add2ArgsUncurried = F.Uncurry(add2ArgsCurried);
            int result = add2ArgsUncurried(1, 2);

            // Assert
            result.Should().Be(add2ArgsResult);
        }

        [TestMethod]
        public void UncurryFunctionToThreeParametersShouldSucceed()
        {
            // Arrange
            Func<int, Func<int, Func<int, int>>> add3ArgsCurried = (int t1) => (int t2) => (int t3) => t1 + t2 + t3;
            int add3ArgsResult = add3ArgsCurried(1)(2)(3);

            // Act
            Func<int, int, int, int> add3ArgsUncurried = F.Uncurry(add3ArgsCurried);
            int result = add3ArgsUncurried(1, 2, 3);

            // Assert
            result.Should().Be(add3ArgsResult);
        }

        [TestMethod]
        public void UncurryFunctionToFourParametersShouldSucceed()
        {
            // Arrange
            Func<int, Func<int, Func<int, Func<int, int>>>> add4ArgsCurried = (int t1) => (int t2) => (int t3) => (int t4) => t1 + t2 + t3 + t4;
            int add4ArgsResult = add4ArgsCurried(1)(2)(3)(4);

            // Act
            Func<int, int, int, int, int> add4ArgsUncurried = F.Uncurry(add4ArgsCurried);
            int result = add4ArgsUncurried(1, 2, 3, 4);

            // Assert
            result.Should().Be(add4ArgsResult);
        }

        #endregion

    }
}
