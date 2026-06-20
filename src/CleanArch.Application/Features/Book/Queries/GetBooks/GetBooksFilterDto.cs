namespace CleanArch.Application.Features.Book.Queries.GetBooks;

public sealed record GetBooksFilterDto(string? Title,
    string? Author,
    int Page = 1,
    int PageSize = 20);