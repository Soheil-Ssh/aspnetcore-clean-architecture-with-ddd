using CleanArch.Domain.Member.Errors;

namespace CleanArch.Application.Features.Member.Commands.BlockMember;

/// <summary>
/// Block member command handler
/// </summary>
/// <param name="memberRepository"></param>
/// <param name="unitOfWork"></param>
public class BlockMemberCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<BlockMemberCommand, Result>
{
    public async Task<Result> Handle(BlockMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await memberRepository.GetByIdAsync(new MemberId(request.Id), cancellationToken);
        if (member is null) return MemberErrors.NotFoundById;

        var blockResult = member.Block();
        if (blockResult.IsFailure) return blockResult.Error;

        await unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}