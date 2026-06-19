namespace CleanArch.Domain.Loan.Errors;

public class LoanErrors
{
    public static readonly Error MemberLoanLimitReached = new("Loan.MemberLoanLimitReached","Member has reached the maximum number of active loans.",ErrorType.Validation);
    public static readonly Error CopyAlreadyBorrowed = new("Loan.CopyAlreadyBorrowed", "This copy is already borrowed.", ErrorType.Validation);
}