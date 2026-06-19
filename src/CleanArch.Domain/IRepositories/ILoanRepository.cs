namespace CleanArch.Domain.IRepositories;

public interface ILoanRepository
{
    Task AddAsync(Loan.Loan loan, CancellationToken cancellationToken = default);
    Task<Loan.Loan?> GetByIdAsync(LoanId id, CancellationToken cancellationToken = default);
    Task<bool> ExistActiveLoanForCopyAsync(BookCopyId id, CancellationToken cancellationToken = default);
    Task<int> GetActiveLoanCountByMemberIdAsync(MemberId id, CancellationToken cancellationToken = default);
}