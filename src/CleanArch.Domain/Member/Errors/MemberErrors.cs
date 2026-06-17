namespace CleanArch.Domain.Member.Errors;

public static class MemberErrors
{
    public static readonly Error DuplicateEmail = new("Member.DuplicateEmail", "A member with this email address already exists.", ErrorType.Conflict);
    public static readonly Error NotFoundById = new("Member.NotFoundById", "Member was not found.", ErrorType.NotFound);
    public static readonly Error AlreadyBlocked = new("Member.AlreadyBlocked", "Member is already blocked.", ErrorType.Validation);
    public static readonly Error NotBlocked = new("Member.NotBlocked", "Member is not blocked.", ErrorType.Validation);
}