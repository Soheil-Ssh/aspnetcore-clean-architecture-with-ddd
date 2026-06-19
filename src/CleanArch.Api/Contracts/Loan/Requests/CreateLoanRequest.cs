namespace CleanArch.Api.Contracts.Loan.Requests;

public sealed record CreateLoanRequest(Guid BookId, Guid BookCopyId, Guid MemberId);