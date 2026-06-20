using CleanArch.Application.Features.Book.Common;
using CleanArch.Application.IQueries;

namespace CleanArch.Application.Features.Book.Queries.GetBooks;

/// <summary>
/// Get all books with filter command handler
/// </summary>
/// <param name="bookQueries"></param>
public sealed class GetBooksQueryHandler(IBookQueries bookQueries) : IRequestHandler<GetBooksQuery, Result<PagedResult<BookDto>>>
{
    public async Task<Result<PagedResult<BookDto>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await bookQueries.GetBooksAsync(request.Filter, cancellationToken);
        return Result<PagedResult<BookDto>>.Success(books);
    }
}