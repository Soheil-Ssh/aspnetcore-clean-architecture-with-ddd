namespace CleanArch.Application.Features.Member.Commands.CreateMember;

public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
{
    public CreateMemberCommandValidator()
    {
        // First name
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);

        // Last name
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);

        // Email
        RuleFor(x => x.Email).NotEmpty().Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").MaximumLength(256);
    }
}