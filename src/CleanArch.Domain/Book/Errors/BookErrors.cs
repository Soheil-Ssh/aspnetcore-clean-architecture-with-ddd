namespace CleanArch.Domain.Book.Errors;

public static class BookErrors
{
    public static readonly Error EmptyTitle = new("Book.EmptyTitle", "Book title cannot be empty.", ErrorType.Validation);
    public static readonly Error EmptyAuthor = new("Book.EmptyAuthor", "Book author cannot be empty.", ErrorType.Validation);
    public static readonly Error EmptyPublisher = new("Book.EmptyPublisher", "Book publisher cannot be empty.", ErrorType.Validation);
    public static readonly Error DuplicateBarcode = new("Book.DuplicateBarcode", "A copy with this barcode already exists for this book.", ErrorType.Validation);
    public static readonly Error CopyNotFound = new("Book.CopyNotFound", "The requested book copy was not found.", ErrorType.NotFound);
    public static readonly Error CannotRemoveBorrowedCopy = new("Book.CannotRemoveBorrowedCopy", "You cannot remove a borrowed copy of the book.", ErrorType.Validation);
    public static readonly Error NotFoundById = new("Book.NotFoundById", "Book with the specified ID was not found.", ErrorType.NotFound);
}