namespace CleanArch.Api.Contracts.Member.Responses;

public sealed record GetMemberByIdResponse(Guid Id,
    string FullName,
    string Email,
    bool IsBlocked,
    int MaxLoanCount,
    DateTime CreateAt,
    DateTime UpdateAt);