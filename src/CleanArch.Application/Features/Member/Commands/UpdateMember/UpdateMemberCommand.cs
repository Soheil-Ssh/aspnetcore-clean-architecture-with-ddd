namespace CleanArch.Application.Features.Member.Commands.UpdateMember;

public sealed record UpdateMemberCommand(Guid Id,
    string FirstName,
    string LastName,
    string Email) : IRequest<Result>;