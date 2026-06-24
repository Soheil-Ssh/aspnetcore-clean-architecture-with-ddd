using CleanArch.Domain.Book.Errors;
using CleanArch.Domain.Book.ValueObjects;

namespace CleanArch.Domain.Book;

public sealed class Book : AggregateRoot<BookId>
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Publisher { get; private set; }
    public Isbn Isbn { get; private set; }
    public PublishYear PublishYear { get; private set; }

    private readonly List<BookCopy> _copies = [];
    public IReadOnlyCollection<BookCopy> Copies => _copies;

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Book() { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Book(BookId id,
        string title,
        string author,
        string publisher,
        Isbn isbn,
        PublishYear publishYear) : base(id)
    {
        Title = title;
        Author = author;
        Publisher = publisher;
        Isbn = isbn;
        PublishYear = publishYear;
    }

    public static Result<Book> Create(string title,
        string author,
        string publisher,
        Isbn isbn,
        PublishYear publishYear)
    {
        if (string.IsNullOrWhiteSpace(title))
            return BookErrors.EmptyTitle;

        if (string.IsNullOrWhiteSpace(author))
            return BookErrors.EmptyAuthor;

        if (string.IsNullOrWhiteSpace(publisher))
            return BookErrors.EmptyPublisher;

        return new Book(BookId.New(),
            title.Trim(),
            author.Trim(),
            publisher.Trim(),
            isbn,
            publishYear);
    }

    public Result Update(string title,
        string author,
        string publisher,
        Isbn isbn,
        PublishYear publishYear)
    {
        if (string.IsNullOrWhiteSpace(title))
            return BookErrors.EmptyTitle;

        if (string.IsNullOrWhiteSpace(author))
            return BookErrors.EmptyAuthor;

        if (string.IsNullOrWhiteSpace(publisher))
            return BookErrors.EmptyPublisher;

        Title = title;
        Author = author;
        Publisher = publisher;
        Isbn = isbn;
        PublishYear = publishYear;

        return Result.Success();
    }

    public Result<Guid> AddCopy(Barcode barcode)
    {
        if (_copies.Any(c => c.Barcode.Value == barcode.Value))
            return BookErrors.DuplicateBarcode;

        var copyResult = BookCopy.Create(barcode);
        if (copyResult.IsFailure)
            return copyResult.Error;

        _copies.Add(copyResult.Data);
        return copyResult.Data.Id.Value;
    }

    public Result RemoveCopy(BookCopyId copyId)
    {
        var copy = _copies.FirstOrDefault(c => c.Id == copyId);
        if (copy is null)
            return BookErrors.CopyNotFound;

        if (copy.Status == CopyStatus.Borrowed)
            return BookErrors.CannotRemoveBorrowedCopy;

        _copies.Remove(copy);
        return Result.Success();
    }

    public Result BorrowCopy(BookCopyId copyId)
    {
        var copy = _copies.FirstOrDefault(c => c.Id == copyId);

        if (copy is null)
            return BookErrors.CopyNotFound;

        return copy.MarkAsBorrowed();
    }
}