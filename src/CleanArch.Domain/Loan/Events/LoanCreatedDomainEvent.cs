using CleanArch.Domain.Book;
using CleanArch.Domain.Member;

namespace CleanArch.Domain.Loan.Events;

public sealed record LoanCreatedDomainEvent(LoanId LoanId,
    MemberId MemberId,
    BookId BookId,
    BookCopyId BookCopyId) : IDomainEvent;