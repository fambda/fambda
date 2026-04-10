using System.Collections.Immutable;
using FluentAssertions;
using Xunit;

namespace Fambda;

public class DataResultTests
{
    #region DataResult

    [Fact]
    public void ImplicitConversion_ErrorTechnicalToDataResult_DoesNotThrow()
    {
        // Arrange
        var error = new Error.Unexpected(new StackOverflowException());

        // Act
        Action act = () => { DataResult<string> dataResult = error; };

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void ImplicitConversion_ErrorProblemToDataResult_DoesNotThrow()
    {
        // Arrange
        var error = new Error.Expected("code", "message");

        // Act
        Action act = () => { DataResult<string> dataResult = error; };

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void ImplicitConversion_ErrorMultiToDataResult_DoesNotThrow()
    {
        // Arrange
        var technicalError = new Error.Unexpected(new StackOverflowException());
        var problemError = new Error.Expected("code", "message");
        var error = new Error.Multi(new List<Error>() { technicalError, problemError }.ToImmutableList());

        // Act
        Action act = () => { DataResult<string> dataResult = error; };

        // Assert
        act.Should().NotThrow();
    }

    #endregion

    #region Match

    [Fact]
    public void Match_ReturnsFailureResult()
    {
        // Arrange
        var technicalError = new Error.Unexpected(new StackOverflowException());
        var problemError = new Error.Expected("code", "message");
        var error = new Error.Multi(new List<Error>() { technicalError, problemError }.ToImmutableList());
        DataResult<string> dataResult = error;

        // Act
        var result = dataResult.Match(
                                Failure: (x) => $"DataResult=Failure({x.GetType().Name})",
                                Success: (x) => $"DataResult=Success({x})"
                            );

        // Assert
        result.Should().Be("DataResult=Failure(Multi)");
    }

    [Fact]
    public void Match_ReturnsSuccessResult()
    {
        // Arrange
        var value = "value";
        DataResult<string> dataResult = value;

        // Act
        var result = dataResult.Match(
                                Failure: (x) => $"DataResult=Failure({x.GetType().Name})",
                                Success: (x) => $"DataResult=Success({x})"
                            );

        // Assert
        result.Should().Be("DataResult=Success(value)");
    }

    #endregion

}
