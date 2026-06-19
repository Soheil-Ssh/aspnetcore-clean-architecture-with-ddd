namespace CleanArch.Domain.IRepositories;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cancellationToken = default);
}