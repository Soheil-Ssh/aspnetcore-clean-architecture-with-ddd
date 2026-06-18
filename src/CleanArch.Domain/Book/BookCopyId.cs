namespace CleanArch.Domain.Book;

public sealed record BookCopyId(Guid Value)
{
    public static BookCopyId New()
        => new(Guid.NewGuid());
}