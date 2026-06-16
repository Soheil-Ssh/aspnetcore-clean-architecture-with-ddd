namespace CleanArch.Domain.Member.Errors;

public static class FullNameErrors
{
    public static readonly Error FirstNameEmpty = new("FullName.FirstNameEmpty", "First name cannot be empty.", ErrorType.Validation);
    public static readonly Error LastNameEmpty = new("FullName.LastNameEmpty", "Last name cannot be empty.", ErrorType.Validation);
    public static readonly Error FirstNameTooLong = new("FullName.FirstNameTooLong", "First name length is too long.", ErrorType.Validation);
    public static readonly Error LastNameTooLong = new("FullName.LastNameTooLong", "First name length is too long.", ErrorType.Validation);
}