namespace CleanArch.Domain.IRepositories;

public interface IBookRepository
{
    Task<Book.Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Book.Book book, CancellationToken cancellationToken = default);
    void Update(Book.Book book);
}