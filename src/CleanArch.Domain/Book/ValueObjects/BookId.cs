namespace CleanArch.Domain.Book.ValueObjects;

public sealed record BookId(Guid Value)
{
    public static BookId New()
        => new(Guid.NewGuid());
}