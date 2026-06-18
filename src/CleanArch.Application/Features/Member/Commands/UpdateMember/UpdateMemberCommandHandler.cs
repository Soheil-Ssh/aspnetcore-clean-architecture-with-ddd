using CleanArch.Domain.Member.Errors;
using CleanArch.Domain.Member.ValueObjects;

namespace CleanArch.Application.Features.Member.Commands.UpdateMember;

/// <summary>
/// Update member command handler
/// </summary>
/// <param name="memberRepository"></param>
/// <param name="unitOfWork"></param>
public sealed class UpdateMemberCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateMemberCommand, Result>
{
    public async Task<Result> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await memberRepository.GetByIdAsync(request.Id, cancellationToken);
        if (member is null) return MemberErrors.NotFoundById;

        var emailResult = Email.Create(request.Email);
        if (emailResult.IsFailure) return emailResult.Error;

        var isExistByEmail = await memberRepository.IsExistByEmailAsync(request.Id, emailResult.Data.Value, cancellationToken);
        if (isExistByEmail) return MemberErrors.DuplicateEmail;

        var fullNameResult = FullName.Create(request.FirstName, request.LastName);
        if (fullNameResult.IsFailure) return fullNameResult.Error;

        member.Update(fullNameResult.Data, emailResult.Data);
        await unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}