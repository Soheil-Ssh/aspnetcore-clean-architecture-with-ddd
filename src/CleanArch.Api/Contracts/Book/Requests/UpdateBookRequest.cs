namespace CleanArch.Api.Contracts.Book.Requests;

public sealed record UpdateBookRequest(string Title,
    string Author,
    string Publisher,
    string Isbn,
    int PublishYear);