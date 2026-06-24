using CleanArch.Domain.Member.Errors;
using CleanArch.Domain.Member.ValueObjects;

namespace CleanArch.Domain.Member;

public sealed class Member : AggregateRoot<MemberId>
{
    public FullName FullName { get; private set; }
    public Email Email { get; private set; }
    public bool IsBlocked { get; private set; }
    public int MaxLoanCount { get; private set; }

    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Member() { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Member(MemberId id,
        FullName fullName,
        Email email) : base(id)
    {
        FullName = fullName;
        Email = email;
        IsBlocked = false;
        MaxLoanCount = 5;
    }

    public static Result<Member> Create(FullName fullName, Email email)
        => new Member(MemberId.New(), fullName, email);

    public Result Update(FullName fullName, Email email)
    {
        FullName = fullName;
        Email = email;

        return Result.Success();
    }

    public Result Block()
    {
        if (IsBlocked) return MemberErrors.AlreadyBlocked;

        IsBlocked = true;
        return Result.Success();
    }

    public Result Unblock()
    {
        if (!IsBlocked) return MemberErrors.NotBlocked;

        IsBlocked = false;
        return Result.Success();
    }
}