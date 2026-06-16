namespace CleanArch.Api.Contracts.Book.Requests;

public sealed record CreateBookRequest(string Title,
    string Author,
    string Publisher,
    string Isbn,
    int PublishYear);