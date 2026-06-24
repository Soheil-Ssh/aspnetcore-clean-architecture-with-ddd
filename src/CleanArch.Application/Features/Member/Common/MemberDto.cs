namespace CleanArch.Application.Features.Member.Common;

public sealed record MemberDto(Guid Id,
    string FullName,
    string Email,
    bool IsBlocked,
    int MaxLoanCount,
    DateTime CreateAt,
    DateTime UpdateAt);