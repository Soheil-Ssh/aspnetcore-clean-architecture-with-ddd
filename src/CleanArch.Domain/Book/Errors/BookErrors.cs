namespace CleanArch.Domain.Book.Errors;

public static class BookErrors
{
    public static readonly Error EmptyTitle = new ("Book.EmptyTitle", "Book title cannot be empty.", ErrorType.Validation);
    public static readonly Error EmptyAuthor = new ("Book.EmptyAuthor", "Book author cannot be empty.", ErrorType.Validation);
    public static readonly Error EmptyPublisher = new ("Book.EmptyPublisher", "Book publisher cannot be empty.", ErrorType.Validation);
    public static readonly Error DuplicateBarcode = new("Book.DuplicateBarcode", "", ErrorType.Validation);
    public static readonly Error CopyNotFound = new("Book.CopyNotFound", "", ErrorType.Validation);
    public static readonly Error CannotRemoveBorrowedCopy = new("Book.CannotRemoveBorrowedCopy", "", ErrorType.Validation);
}