namespace CleanArch.Application.Features.Member.Commands.UnblockMember;

public sealed record UnblockMemberCommand(Guid Id) : IRequest<Result>;