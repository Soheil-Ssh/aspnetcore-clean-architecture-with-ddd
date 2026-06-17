using CleanArch.Application.Features.Book.Common;
using CleanArch.Application.IQueries;
using CleanArch.Domain.Book.Errors;

namespace CleanArch.Application.Features.Book.Queries.GetBookById;

public sealed class GetBookByIdQueryHandler(IBookQueries bookQueries)
    : IRequestHandler<GetBookByIdQuery, Result<BookDto>>
{
    public async Task<Result<BookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await bookQueries.GetByIdAsync(request.Id, cancellationToken);
        if (book is null) return BookErrors.NotFoundById;

        return book;
    }
}