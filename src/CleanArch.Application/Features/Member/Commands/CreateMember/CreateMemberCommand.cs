namespace CleanArch.Application.Features.Member.Commands.CreateMember;

public sealed record CreateMemberCommand(string FirstName, string LastName, string Email) : IRequest<Result<Guid>>;