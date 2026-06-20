using CleanArch.Application.Features.Book.Common;

namespace CleanArch.Application.Features.Book.Queries.GetBooks;

public sealed record GetBooksQuery(GetBooksFilterDto Filter) : IRequest<Result<PagedResult<BookDto>>>;