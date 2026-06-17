using CleanArch.Application.Features.Member.Common;
using CleanArch.Application.IQueries;
using CleanArch.Domain.Member.Errors;

namespace CleanArch.Application.Features.Member.Queries.GetMemberById;

public sealed class GetMemberByIdQueryHandler(IMemberQueries memberRepository)
    : IRequestHandler<GetMemberByIdQuery, Result<MemberDto>>
{
    public async Task<Result<MemberDto>> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
    {
        var member = await memberRepository.GetByIdAsync(request.Id, cancellationToken);
        if (member is null) return MemberErrors.NotFoundById;

        return member;
    }
}