namespace CleanArch.Infrastructure.Repositories;

public class BookCommandRepository(ApplicationDbContext context) : IBookRepository
{
    public async Task<Book?> GetByIdAsync(BookId id, CancellationToken cancellationToken = default)
        => await context.Books.Include(b => b.Copies)
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task AddAsync(Book book, CancellationToken cancellationToken = default)
    {
        await context.Books.AddAsync(book, cancellationToken);
    }

    public void Update(Book book)
    {
        context.Books.Update(book);
    }
}