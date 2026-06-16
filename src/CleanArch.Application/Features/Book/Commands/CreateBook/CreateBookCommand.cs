namespace CleanArch.Application.Features.Book.Commands.CreateBook;

public sealed record CreateBookCommand(string Title,
    string Author,
    string Publisher,
    string Isbn,
    int PublishYear) : IRequest<Result<Guid>>;