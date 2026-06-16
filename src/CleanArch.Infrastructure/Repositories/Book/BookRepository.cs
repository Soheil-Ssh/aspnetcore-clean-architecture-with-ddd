using CleanArch.Domain.Book.ValueObjects;
using CleanArch.Domain.IRepositories.Book;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Repositories.Book;

public class BookRepository(ApplicationDbContext context) : IBookRepository
{
    public async Task<Domain.Book.Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await context.Books.Include(b => b.Copies)
            .FirstOrDefaultAsync(b => b.Id == new BookId(id), cancellationToken);

    public async Task AddAsync(Domain.Book.Book book, CancellationToken cancellationToken)
    {
        await context.Books.AddAsync(book, cancellationToken);
    }

    public void Update(Domain.Book.Book book)
    {
        context.Books.Update(book);
    }
}