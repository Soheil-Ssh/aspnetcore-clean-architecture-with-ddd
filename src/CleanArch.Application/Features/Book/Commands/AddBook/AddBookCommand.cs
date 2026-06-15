namespace CleanArch.Application.Features.Book.Commands.AddBook;

public sealed record AddBookCommand(string Title,
    string Author,
    string Publisher,
    string Isbn,
    int PublishYear) : IRequest<Result<Guid>>;