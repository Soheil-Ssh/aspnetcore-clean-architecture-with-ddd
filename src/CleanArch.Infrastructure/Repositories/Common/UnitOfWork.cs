using CleanArch.Domain.IRepositories.Common;

namespace CleanArch.Infrastructure.Repositories.Common;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public Task<int> SaveAsync(CancellationToken cancellationToken = default)
        => context.SaveChangesAsync(cancellationToken);
}