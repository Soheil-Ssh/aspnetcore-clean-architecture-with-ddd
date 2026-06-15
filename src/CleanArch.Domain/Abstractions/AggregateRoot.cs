namespace CleanArch.Domain.Abstractions;

public class AggregateRoot<TKey> : Entity<TKey> where TKey : notnull
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected AggregateRoot(TKey id)
        : base(id) { }

    protected AggregateRoot() { }

    public IReadOnlyCollection<IDomainEvent> DomainEvents =>
        _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public IReadOnlyList<IDomainEvent> PopDomainEvents()
    {
        var events = _domainEvents.ToList();

        _domainEvents.Clear();

        return events;
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}