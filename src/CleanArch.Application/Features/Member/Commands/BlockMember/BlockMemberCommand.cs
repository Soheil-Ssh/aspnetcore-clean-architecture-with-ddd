namespace CleanArch.Application.Features.Member.Commands.BlockMember;

public sealed record BlockMemberCommand(Guid Id) : IRequest<Result>;