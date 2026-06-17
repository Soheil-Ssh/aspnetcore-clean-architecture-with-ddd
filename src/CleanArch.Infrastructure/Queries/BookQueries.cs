using CleanArch.Application.Features.Book.Common;
using CleanArch.Application.IQueries;
using CleanArch.Domain.Book.ValueObjects;

namespace CleanArch.Infrastructure.Queries;

public class BookQueries(ApplicationDbContext context) : IBookQueries
{
    public async Task<BookDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Books.AsNoTracking()
            .Where(b => b.Id == new BookId(id))
            .Select(b => new BookDto(b.Id.Value, b.Title, b.Author, b.Publisher, b.Isbn.Value, b.PublishYear.Value, b.CreatedAt, b.UpdatedAt))
            .FirstOrDefaultAsync(cancellationToken);
}