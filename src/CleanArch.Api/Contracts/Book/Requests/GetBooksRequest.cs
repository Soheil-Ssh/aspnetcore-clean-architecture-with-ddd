namespace CleanArch.Api.Contracts.Book.Requests;

public sealed record GetBooksRequest(string? Title,
    string? Author,
    int Page = 1,
    int PageSize = 20);