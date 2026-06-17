using CleanArch.Domain.Member.Errors;
using CleanArch.Domain.Member.ValueObjects;

namespace CleanArch.Application.Features.Member.Commands.CreateMember;

/// <summary>
/// Create member command handler
/// </summary>
/// <param name="memberRepository"></param>
/// <param name="unitOfWork"></param>
public class CreateMemberCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateMemberCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var emailResult = Email.Create(request.Email);
        if (emailResult.IsFailure) return emailResult.Error;

        var isExistByEmail = await memberRepository.IsExistByEmailAsync(emailResult.Data.Value, cancellationToken);
        if (isExistByEmail) return MemberErrors.DuplicateEmail;

        var fullNameResult = FullName.Create(request.FirstName, request.LastName);
        if (fullNameResult.IsFailure) return fullNameResult.Error;

        var memberResult = Domain.Member.Member.Create(fullNameResult.Data, emailResult.Data);
        if (memberResult.IsFailure) return memberResult.Error;

        await memberRepository.AddAsync(memberResult.Data, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);

        return memberResult.Data.Id.Value;
    }
}