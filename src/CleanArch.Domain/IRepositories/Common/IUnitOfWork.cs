namespace CleanArch.Domain.IRepositories.Common;

public interface IUnitOfWork
{
    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}