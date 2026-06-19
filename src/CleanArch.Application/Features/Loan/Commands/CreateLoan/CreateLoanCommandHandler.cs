namespace CleanArch.Application.Features.Loan.Commands.CreateLoan;

/// <summary>
/// Create loan command handler
/// </summary>
/// <param name="memberRepository"></param>
/// <param name="bookRepository"></param>
/// <param name="loanRepository"></param>
/// <param name="unitOfWork"></param>
public sealed class CreateLoanCommandHandler(IMemberRepository memberRepository,
    IBookRepository bookRepository,
    ILoanRepository loanRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateLoanCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var memberId = new MemberId(request.MemberId);
        var member = await memberRepository.GetByIdAsync(memberId, cancellationToken);
        if (member is null) return MemberErrors.NotFoundById;
        if (member.IsBlocked) return MemberErrors.Blocked;

        var bookId = new BookId(request.BookId);
        var book = await bookRepository.GetByIdAsync(bookId, cancellationToken);
        if (book is null) return BookErrors.NotFoundById;

        var bookCopyId = new BookCopyId(request.BookCopyId);

        var copy = book.Copies.FirstOrDefault(c => c.Id == bookCopyId);
        if (copy is null) return BookErrors.CopyNotFound;

        if (copy.Status != CopyStatus.Available) return BookCopyErrors.NotAvailable;

        var activeLoanCount = await loanRepository.
                GetActiveLoanCountByMemberIdAsync(memberId, cancellationToken);
        if (activeLoanCount > member.MaxLoanCount) return LoanErrors.MemberLoanLimitReached;

        var existingLoan = await loanRepository.ExistActiveLoanForCopyAsync(bookCopyId, cancellationToken);
        if (existingLoan) return LoanErrors.CopyAlreadyBorrowed;

        var loanResult = Domain.Loan.Loan.Create(memberId, bookId, bookCopyId);
        if (loanResult.IsFailure) return loanResult.Error;

        await loanRepository.AddAsync(loanResult.Data, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);

        return loanResult.Data.Id.Value;
    }
}