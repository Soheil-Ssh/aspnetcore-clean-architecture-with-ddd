namespace CleanArch.Infrastructure.Repositories;

public class LoanRepository(ApplicationDbContext context) : ILoanRepository
{
    public async Task AddAsync(Loan loan, CancellationToken cancellationToken = default)
    {
        await context.Loans.AddAsync(loan, cancellationToken);
    }

    public async Task<Loan?> GetByIdAsync(LoanId id, CancellationToken cancellationToken = default)
        => await context.Loans.FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

    public async Task<bool> ExistActiveLoanForCopyAsync(BookCopyId id, CancellationToken cancellationToken = default)
        => await context.Loans.AnyAsync(l => l.BookCopyId == id && l.ReturnedAt == null, cancellationToken);

    public async Task<int> GetActiveLoanCountByMemberIdAsync(MemberId id, CancellationToken cancellationToken = default)
        => await context.Loans.CountAsync(l => l.MemberId == id && l.ReturnedAt == null, cancellationToken);
}