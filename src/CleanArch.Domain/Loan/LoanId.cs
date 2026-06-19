namespace CleanArch.Domain.Loan;

public sealed record LoanId(Guid Value)
{
    public static LoanId New()
        => new LoanId(Guid.NewGuid());
}