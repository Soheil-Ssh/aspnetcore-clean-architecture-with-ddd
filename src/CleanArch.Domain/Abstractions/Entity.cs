namespace CleanArch.Domain.Abstractions;

public abstract class Entity<TKey>
{
    public TKey Id { get; } = default!;
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    protected Entity(TKey id)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow;
    }

    protected Entity() { }

    protected void SetUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TKey> other)
            return false;

        return GetType() == other.GetType() && EqualityComparer<TKey>.Default.Equals(Id, other.Id);
    }

    public override int GetHashCode()
        => HashCode.Combine(GetType(), Id);

    public static bool operator ==(Entity<TKey>? left, Entity<TKey>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TKey>? left, Entity<TKey>? right)
    {
        return !Equals(left, right);
    }
}