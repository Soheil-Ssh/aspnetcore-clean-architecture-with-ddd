namespace CleanArch.Domain.IRepositories.Book;

public interface IBookRepository
{
    Task AddAsync(Domain.Book.Book book, CancellationToken cancellationToken);
}