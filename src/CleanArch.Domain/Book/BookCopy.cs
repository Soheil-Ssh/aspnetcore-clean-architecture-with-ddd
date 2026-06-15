using CleanArch.Domain.Book.Errors;
using CleanArch.Domain.Book.ValueObjects;

namespace CleanArch.Domain.Book;

public class BookCopy : Entity<BookCopyId>
{
    public CopyStatus Status { get; private set; }
    public Barcode Barcode { get; private set; }

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public BookCopy() { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private BookCopy(BookCopyId id, Barcode barcode) : base(id)
    {
        Barcode = barcode;
        Status = CopyStatus.Available;
    }

    public static Result<BookCopy> Create(Barcode barcode)
        => new BookCopy(BookCopyId.New(), barcode);

    public Result MarkAsBorrowed()
    {
        if (Status != CopyStatus.Available)
            return BookCopyErrors.NotAvailable;

        Status = CopyStatus.Borrowed;
        return Result.Success();
    }

    public Result MarkAsReturned()
    {
        if (Status != CopyStatus.Borrowed)
            return BookCopyErrors.NotBorrowed;

        Status = CopyStatus.Available;
        return Result.Success();
    }

    public Result MarkAsLost()
    {
        if (Status == CopyStatus.Borrowed)
            return BookCopyErrors.CannotMarkBorrowedCopyAsLost;

        if (Status == CopyStatus.Lost)
            return BookCopyErrors.AlreadyLost;

        Status = CopyStatus.Lost;
        return Result.Success();
    }

    public Result MarkAsDamaged()
    {
        if (Status == CopyStatus.Borrowed)
            return BookCopyErrors.CannotMarkBorrowedCopyAsDamaged;

        if (Status == CopyStatus.Damaged)
            return BookCopyErrors.AlreadyDamaged;

        Status = CopyStatus.Damaged;
        return Result.Success();
    }
}