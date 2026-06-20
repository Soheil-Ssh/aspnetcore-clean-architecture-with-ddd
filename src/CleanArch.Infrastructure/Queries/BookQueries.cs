using CleanArch.Application.Common.Pagination;
using CleanArch.Application.Features.Book.Common;
using CleanArch.Application.Features.Book.Queries.GetBooks;
using CleanArch.Application.IQueries;

namespace CleanArch.Infrastructure.Queries;

public class BookQueries(ApplicationDbContext context) : IBookQueries
{
    public async Task<PagedResult<BookDto>> GetBooksAsync(GetBooksFilterDto filter, CancellationToken cancellationToken = default)
    {
        var query = context.Books.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Title))
            query = query.Where(b => b.Title.Contains(filter.Title.Trim()));

        if (!string.IsNullOrWhiteSpace(filter.Author))
            query = query.Where(b => b.Author.Contains(filter.Author.Trim()));

        int page = filter.Page <= 0 ? 1 : filter.Page;
        int take = filter.PageSize <= 0 ? 10 : filter.PageSize;
        int skip = (page - 1) * take;
        int count = await query.CountAsync(cancellationToken);

        if (skip >= count)
        {
            page = (int)Math.Ceiling(count / (double)take);
            skip = (page - 1) * take;
        }

        var items = await query.AsNoTracking()
            .Select(b => new BookDto(b.Id.Value, b.Title, b.Author, b.Publisher, b.Isbn.Value, b.PublishYear.Value, b.CreatedAt, b.UpdatedAt))
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);
        return new PagedResult<BookDto>(items, page, count, take);
    }

    public async Task<BookDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Books.AsNoTracking()
            .Where(b => b.Id == new BookId(id))
            .Select(b => new BookDto(b.Id.Value, b.Title, b.Author, b.Publisher, b.Isbn.Value, b.PublishYear.Value, b.CreatedAt, b.UpdatedAt))
            .FirstOrDefaultAsync(cancellationToken);
}