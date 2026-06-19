namespace CleanArch.Application.Features.Loan.Commands.CreateLoan;

public sealed record CreateLoanCommand(Guid MemberId,
    Guid BookId,
    Guid BookCopyId) : IRequest<Result<Guid>>;