using CleanArch.Application.Features.Member.Common;

namespace CleanArch.Application.Features.Member.Queries.GetMemberById;

public sealed record GetMemberByIdQuery(Guid Id) : IRequest<Result<MemberDto>>;