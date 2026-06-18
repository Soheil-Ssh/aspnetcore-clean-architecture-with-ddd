using CleanArch.Domain.Book.ValueObjects;
using CleanArch.Domain.Loan.ValueObjects;
using CleanArch.Domain.Member.ValueObjects;

namespace CleanArch.Domain.Loan;

public sealed class Loan : AggregateRoot<LoanId>
{
    public MemberId MemberId { get; private set; }
    public BookCopyId BookCopyId { get; private set; }
    public DateTime BorrowedAt { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? ReturnedAt { get; private set; }
    public int RenewalCount { get; private set; }
    public bool IsReturned => ReturnedAt.HasValue;

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Loan() { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Loan(LoanId id,
        MemberId memberId,
        BookCopyId bookCopyId,
        DateTime borrowedAt,
        DateTime dueDate) : base(id)
    {
        MemberId = memberId;
        BookCopyId = bookCopyId;
        BorrowedAt = borrowedAt;
        DueDate = dueDate;
        RenewalCount = 0;
    }
}