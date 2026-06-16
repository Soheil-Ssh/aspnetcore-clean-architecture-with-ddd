namespace CleanArch.Api.Common.Extensions;

/// <summary>
/// Provides extension methods to convert <see cref="Result"/> and <see cref="Result{TData}"/> objects
/// into ASP.NET Core <see cref="IActionResult"/> responses.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Converts a non‑generic <see cref="Result"/> to an <see cref="IActionResult"/>.
    /// Success results become an HTTP 200 OK with a successful API response body;
    /// failure results become a problem details response with the appropriate HTTP status code.
    /// </summary>
    /// <param name="result">The <see cref="Result"/> to convert.</param>
    /// <returns>An <see cref="OkObjectResult"/> on success, or an <see cref="ObjectResult"/> containing
    /// <see cref="ApiProblemDetails"/> on failure.</returns>
    public static IActionResult ToActionResult(this Result result)
        => result.IsSuccess ? new OkObjectResult(ApiResponse.Success()) : CreateProblemDetails(result.Error);

    /// <summary>
    /// Converts a successful <see cref="Result{T}"/> to an <see cref="IActionResult"/> with HTTP 200 OK,
    /// wrapping the data in an <see cref="ApiResponse{T}"/>. On failure, returns a problem details response
    /// with the appropriate HTTP status code.
    /// </summary>
    /// <typeparam name="T">The type of the data contained in a successful <see cref="Result{T}"/>.</typeparam>
    /// <param name="result">The <see cref="Result{T}"/> instance to convert.</param>
    /// <returns>An <see cref="OkObjectResult"/> containing <see cref="ApiResponse{T}"/> on success,
    /// or an <see cref="ObjectResult"/> with problem details on failure.</returns>
    // ReSharper disable once ConvertToExtensionBlock
    public static IActionResult ToActionResult<T>(this Result<T> result)
        => result.IsSuccess
            ? new OkObjectResult(ApiResponse<T>.Success(result.Data))
            : CreateProblemDetails(result.Error);

    /// <summary>
    /// Converts a successful <see cref="Result{T}"/> to an <see cref="IActionResult"/> with HTTP 200 OK,
    /// mapping the success data to a different type using the provided <paramref name="mapper"/>.
    /// On failure, returns a problem details response directly without mapping.
    /// </summary>
    /// <typeparam name="T">The type of the source data in the <see cref="Result{T}"/>.</typeparam>
    /// <typeparam name="TResponse">The type to map the success data to.</typeparam>
    /// <param name="result">The <see cref="Result{T}"/> instance to convert.</param>
    /// <returns>An <see cref="OkObjectResult"/> containing <see cref="ApiResponse{TResponse}"/> on success,
    /// or an <see cref="ObjectResult"/> with problem details on failure.</returns>
    public static IActionResult ToActionResult<T, TResponse>(this Result<T> result)
    {
        if (!result.IsSuccess)
            return CreateProblemDetails(result.Error);

        var responseData = result.Data.Adapt<TResponse>();
        return new OkObjectResult(ApiResponse<TResponse>.Success(responseData));
    }

    /// <summary>
    /// Builds an <see cref="ObjectResult"/> with <see cref="ApiProblemDetails"/> from the given error.
    /// The HTTP status code is derived from the error's type via <see cref="ErrorExtensions.GetStatusCode"/>.
    /// </summary>
    /// <param name="error">The error to represent as problem details.</param>
    /// <returns>An <see cref="ObjectResult"/> with the mapped status code and a problem details body.</returns>
    private static ObjectResult CreateProblemDetails(Error error)
    {
        var statusCode = error.GetStatusCode();
        return new ObjectResult(new ApiProblemDetails
        {
            Title = error.Code,
            Detail = error.Description,
            Status = statusCode
        })
        {
            StatusCode = statusCode
        };
    }
}