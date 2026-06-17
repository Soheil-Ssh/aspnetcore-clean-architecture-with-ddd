using CleanArch.Domain.Member.Errors;

namespace CleanArch.Application.Features.Member.Commands.UnblockMember;

/// <summary>
/// Unblock member command handler
/// </summary>
/// <param name="memberRepository"></param>
/// <param name="unitOfWork"></param>
public class UnblockMemberCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UnblockMemberCommand, Result>
{
    public async Task<Result> Handle(UnblockMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await memberRepository.GetByIdAsync(request.Id, cancellationToken);
        if (member is null) return MemberErrors.NotFoundById;

        var blockResult = member.Unblock();
        if (blockResult.IsFailure) return blockResult.Error;

        await unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}