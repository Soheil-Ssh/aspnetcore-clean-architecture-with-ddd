namespace CleanArch.Application.Features.Book.Common;

public record BookDto(Guid Id,
    string Title,
    string Author,
    string Publisher,
    string Isbn,
    int PublisherYear,
    DateTime CreateAt,
    DateTime? UpdateAt);