using CleanArch.Domain.IRepositories.Book;

namespace CleanArch.Infrastructure.Repositories.Book;

public class BookRepository(ApplicationDbContext context) : IBookRepository
{
    public async Task AddAsync(Domain.Book.Book book, CancellationToken cancellationToken)
    {
        await context.Books.AddAsync(book, cancellationToken);
    }
}