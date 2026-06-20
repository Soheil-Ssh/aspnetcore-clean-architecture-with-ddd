using CleanArch.Application.Features.Book.Common;
using CleanArch.Application.Features.Book.Queries.GetBooks;

namespace CleanArch.Application.IQueries;

public interface IBookQueries
{
    Task<PagedResult<BookDto>> GetBooksAsync(GetBooksFilterDto filter, CancellationToken cancellationToken = default);
    Task<BookDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}