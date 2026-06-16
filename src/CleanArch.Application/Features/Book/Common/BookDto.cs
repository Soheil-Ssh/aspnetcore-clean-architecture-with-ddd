namespace CleanArch.Application.Features.Book.Common;

public record BookDto(Guid Id,
    string Title,
    string Author,
    string Publisher,
    string Isbn,
    string PublisherYear,
    DateTime CreateAt,
    DateTime UpdateAt);