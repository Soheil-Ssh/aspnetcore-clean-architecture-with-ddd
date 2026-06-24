using CleanArch.Domain.Abstractions;
using MediatR;

namespace CleanArch.Infrastructure.Repositories;

public class UnitOfWork(ApplicationDbContext context, IMediator mediator) : IUnitOfWork
{
    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        var events = context.ChangeTracker
            .Entries<IAggregateRoot>()
            .SelectMany(x => x.Entity.PopDomainEvents())
            .ToList();

        foreach (var domainEvent in events)
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}