namespace CleanArch.Domain.Book.Errors;

public static class BookCopyErrors
{
    public static readonly Error EmptyBarcode = new("BookCopy.EmptyBarcode", "Book title cannot be empty.", ErrorType.Validation);
    public static readonly Error NotAvailable = new("BookCopy.NotAvailable", "Book copy is not available.");
    public static readonly Error NotBorrowed = new("BookCopy.NotBorrowed", "Book copy is not borrowed.");
    public static readonly Error AlreadyLost =new("BookCopy.AlreadyLost","Book copy is already lost.");
    public static readonly Error AlreadyDamaged =new("BookCopy.AlreadyDamaged","Book copy is already damaged.");
    public static readonly Error CannotMarkBorrowedCopyAsLost =new("BookCopy.CannotMarkBorrowedCopyAsLost","Borrowed copies cannot be marked as lost.");
    public static readonly Error CannotMarkBorrowedCopyAsDamaged =new("BookCopy.CannotMarkBorrowedCopyAsDamaged","Borrowed copies cannot be marked as damaged.");
}