using CleanArch.Domain.Abstractions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CleanArch.Infrastructure.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateAuditableEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateAuditableEntities(
        DbContext? context)
    {
        if (context is null)
            return;

        var utcNow = DateTime.UtcNow;

        var entries = context.ChangeTracker.Entries<IEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(x => x.CreatedAt)
                    .CurrentValue = utcNow;
            }

            if (entry.State is EntityState.Added or EntityState.Modified)
            {
                entry.Property(x => x.UpdatedAt)
                    .CurrentValue = utcNow;
            }
        }
    }
}