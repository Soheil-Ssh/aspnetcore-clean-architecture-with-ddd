namespace CleanArch.Domain.Book;

public sealed record BookId(Guid Value)
{
    public static BookId New()
        => new(Guid.NewGuid());
}