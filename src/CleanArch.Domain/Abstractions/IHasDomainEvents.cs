namespace CleanArch.Domain.Abstractions;

public interface IHasDomainEvents
{
    IReadOnlyList<IDomainEvent> PopDomainEvents();
}