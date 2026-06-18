namespace CleanArch.Domain.Loan.ValueObjects;

public sealed record LoanId(Guid Value)
{
    public static LoanId New()
        => new LoanId(Guid.NewGuid());
}