namespace CleanArch.Domain.Common.Result;

/// <summary>
/// Represents the outcome of an operation that either succeeds or fails, without a return value.
/// Provides an implicit conversion from <see cref="Error"/> to allow direct error propagation.
/// </summary>
public class Result : BaseResult
{
    private Result(bool isSuccess, Error.Error error)
        : base(isSuccess, error) { }

    /// <summary>
    /// Creates a successful result indicating that the operation completed without errors.
    /// </summary>
    /// <returns>A new <see cref="Result"/> representing success.</returns>
    public static Result Success() => new(true, Common.Error.Error.None);

    /// <summary>
    /// Creates a failure result with the specified error.
    /// </summary>
    /// <param name="error">The error describing the failure. Must not be <see cref="Common.Error.Error.None"/>.</param>
    /// <returns>A new <see cref="Result"/> representing failure.</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    public static Result Failure(Error.Error error) => new(false, error);

    /// <summary>
    /// Enables implicit conversion of an <see cref="Error"/> to a failure result,
    /// allowing a method to return an error directly where a <see cref="Result"/> is expected.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    public static implicit operator Result(Error.Error error) => Failure(error);
}

/// <summary>
/// Represents the outcome of an operation that either succeeds and returns data,
/// or fails with an error. Implicit conversions from both the success data and an error are provided.
/// </summary>
/// <typeparam name="TData">The type of data returned on success.</typeparam>
public class Result<TData> : BaseResult
{
    private readonly TData? _data;

    private Result(TData? data, bool isSuccess, Error.Error error) : base(isSuccess, error)
    {
        _data = data;
        IsSuccess = isSuccess;
    }

    /// <summary>
    /// Gets the data produced by a successful operation.
    /// It is highly recommended to check <see cref="IsSuccess"/> before accessing this property.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when accessed on a failure result.</exception>
    public TData Data => IsSuccess
        ? _data!
        : throw new InvalidOperationException("Cannot access data of a failed result.");

    /// <summary>
    /// Indicates whether the operation succeeded. 
    /// When this property is <c>true</c>, the <see cref="Data"/> property can be safely accessed without causing an exception.
    /// </summary>
    public override bool IsSuccess { get; }

    /// <summary>
    /// Creates a successful result containing the provided data.
    /// </summary>
    /// <param name="data">The data to return with the success result.</param>
    /// <returns>A new <see cref="Result{TData}"/> instance representing success.</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    public static Result<TData> Success(TData data) => new(data, true, Common.Error.Error.None);

    /// <summary>
    /// Creates a failure result with the specified error.
    /// </summary>
    /// <param name="error">The error describing the failure. Must not be <see cref="Common.Error.Error.None"/>.</param>
    /// <returns>A new <see cref="Result{TData}"/> instance representing failure.</returns>
    // ReSharper disable once MemberCanBePrivate.Global
    public static Result<TData> Failure(Error.Error error) => new(default, false, error);

    /// <summary>
    /// Enables implicit conversion of a data value to a successful result,
    /// allowing a method to return a value directly where a <see cref="Result{TData}"/> is expected.
    /// </summary>
    /// <param name="data">The data to convert.</param>
    public static implicit operator Result<TData>(TData data) => Success(data);

    /// <summary>
    /// Enables implicit conversion of an <see cref="Error"/> to a failure result,
    /// allowing a method to return an error directly where a <see cref="Result{TData}"/> is expected.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    public static implicit operator Result<TData>(Error.Error error) => Failure(error);
}