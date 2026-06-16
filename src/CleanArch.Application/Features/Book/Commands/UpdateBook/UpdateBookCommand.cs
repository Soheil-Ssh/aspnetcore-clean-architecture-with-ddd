namespace CleanArch.Application.Features.Book.Commands.UpdateBook;

public sealed record UpdateBookCommand(Guid Id,
    string Title,
    string Author,
    string Publisher,
    string Isbn,
    int PublishYear) : IRequest<Result>;