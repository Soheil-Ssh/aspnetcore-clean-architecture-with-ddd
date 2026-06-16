using CleanArch.Application.Features.Book.Common;

namespace CleanArch.Application.Features.Book.Queries.GetBookById;

public sealed record GetBookByIdQuery(Guid Id) : IRequest<Result<BookDto>>;