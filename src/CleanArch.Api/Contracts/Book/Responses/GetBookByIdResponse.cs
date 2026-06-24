namespace CleanArch.Api.Contracts.Book.Responses;

public record GetBookByIdResponse(Guid Id,
    string Title,
    string Author,
    string Publisher,
    string Isbn,
    string PublisherYear,
    DateTime CreateAt,
    DateTime UpdateAt);