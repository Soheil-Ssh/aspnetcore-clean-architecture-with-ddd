namespace CleanArch.Domain.Abstractions;

public interface IEntity
{
    DateTime CreatedAt { get; }
    DateTime UpdatedAt { get; }
}