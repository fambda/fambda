using System.Collections.Immutable;

namespace Fambda;

/// <summary>
/// Represents a DataResult type.
/// </summary>
/// <typeparam name="T">The type of the value to be wrapped.</typeparam>
public readonly struct DataResult<T>
{
    internal Error? Error { get; }
    internal T? Value { get; }


    internal DataResult(T value)
    {
        Error = null;
        Value = value;
    }

    internal DataResult(Error error)
    {
        Error = error;
        Value = default;
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="Fambda.Error"/> to <see cref="DataResult{T}"/>.
    /// </summary>
    /// <param name="error">The error.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator DataResult<T>(Error error)
        => error switch
        {
            Error.Expected expected => new(new Error.Multi(new List<Error>() { expected }.ToImmutableList())),
            Error.Unexpected unexpected => new(new Error.Multi(new List<Error>() { unexpected }.ToImmutableList())),
            Error.Multi multi => new(multi),
            _ => throw new NotImplementedException()
        };

    /// <summary>
    /// Implicit conversion operator from <typeparamref name="T"/> to <see cref="DataResult{T}"/>.
    /// </summary>
    /// <param name="value">T value.</param>
    public static implicit operator DataResult<T>(T value)
        => new(value);

    /// <summary>
    /// Match the Failure and Success of the <see cref="DataResult{T}"/> and return Res.
    /// </summary>
    /// <typeparam name="Res">Return type.</typeparam>
    /// <param name="Failure">Failure match operation.</param>
    /// <param name="Success">Success match operation.</param>
    /// <returns></returns>
    public Res Match<Res>(Func<Error, Res> Failure, Func<T, Res> Success)
        => this.Error is not null ? Failure(this.Error) : Success(this.Value!);
}
