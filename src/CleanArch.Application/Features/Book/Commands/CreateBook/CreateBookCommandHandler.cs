using CleanArch.Domain.Book.ValueObjects;

namespace CleanArch.Application.Features.Book.Commands.CreateBook;

/// <summary>
/// Create book command handler
/// </summary>
/// <param name="bookRepository"></param>
/// <param name="unitOfWork"></param>
public sealed class CreateBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork): IRequestHandler<CreateBookCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var isbnResult = Isbn.Create(request.Isbn);
        if (isbnResult.IsFailure) return isbnResult.Error;

        var publishYearResult = PublishYear.Create(request.PublishYear);
        if (publishYearResult.IsFailure) return publishYearResult.Error;

        var bookResult = Domain.Book.Book.Create(request.Title,
            request.Author,
            request.Publisher,
            isbnResult.Data,
            publishYearResult.Data);
        if (bookResult.IsFailure) return bookResult.Error;


        await bookRepository.AddAsync(bookResult.Data, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);

        return bookResult.Data.Id.Value;
    }
}