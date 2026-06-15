namespace CleanArch.Domain.Book.ValueObjects;

public sealed record BookCopyId(Guid Value)
{
    public static BookCopyId New()
        => new(Guid.NewGuid());
}