namespace CleanArch.Application.Features.Book.Commands.CreateBookCopy;

public class CreateBookCopyCommandValidator : AbstractValidator<CreateBookCopyCommand>
{
    public CreateBookCopyCommandValidator()
    {
        RuleFor(x => x.Barcode)
            .NotEmpty()
            .Matches(@"^LIB-\d{6}$")
            .WithMessage("Barcode format is invalid, Barcode must match the format LIB-123456.");
    }
}