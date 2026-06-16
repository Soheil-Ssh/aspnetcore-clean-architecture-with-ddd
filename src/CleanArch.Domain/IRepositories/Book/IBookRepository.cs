namespace CleanArch.Domain.IRepositories.Book;

public interface IBookRepository
{
    Task<Domain.Book.Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(Domain.Book.Book book, CancellationToken cancellationToken);
}