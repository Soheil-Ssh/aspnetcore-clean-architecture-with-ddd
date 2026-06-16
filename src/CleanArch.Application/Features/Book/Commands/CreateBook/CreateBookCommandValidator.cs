
namespace CleanArch.Application.Features.Book.Commands.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        // Title
        RuleFor(x => x.Title).NotEmpty().MaximumLength(300);

        // Author
        RuleFor(x => x.Author).NotEmpty().MaximumLength(200);

        // Publisher
        RuleFor(x => x.Publisher).NotEmpty().MaximumLength(200);

        // Isbn
        RuleFor(x => x.Isbn).NotEmpty().Must(BeValidIsbn).WithMessage("Invalid ISBN format");

        // PublishYear
        RuleFor(x => x.PublishYear).InclusiveBetween(1450, DateTime.UtcNow.Year);
    }

    private bool BeValidIsbn(string isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn))
            return false;

        isbn = isbn.Replace("-", "").Replace(" ", "");

        if (isbn.Length != 10 && isbn.Length != 13)
            return false;

        return isbn.All(char.IsDigit);
    }
}