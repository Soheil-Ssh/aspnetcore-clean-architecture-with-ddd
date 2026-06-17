using CleanArch.Application.Features.Book.Common;

namespace CleanArch.Application.IQueries;

public interface IBookQueries
{
    Task<BookDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}