using CleanArch.Domain.Book.Errors;
using CleanArch.Domain.Book.ValueObjects;
using CleanArch.Domain.IRepositories;

namespace CleanArch.Application.Features.Book.Commands.UpdateBook;

/// <summary>
/// Update book command handler
/// </summary>
/// <param name="bookCommandRepository"></param>
/// <param name="unitOfWork"></param>
public class UpdateBookCommandHandler(IBookRepository bookCommandRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateBookCommand, Result>
{
    public async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await bookCommandRepository.GetByIdAsync(new BookId(request.Id), cancellationToken);
        if (book is null) return BookErrors.NotFoundById;

        var isbnResult = Isbn.Create(request.Isbn);
        if (isbnResult.IsFailure) return isbnResult.Error;

        var publishYearResult = PublishYear.Create(request.PublishYear);
        if (publishYearResult.IsFailure) return publishYearResult.Error;

        book.Update(request.Title, request.Author, request.Publisher, isbnResult.Data, publishYearResult.Data);
        bookCommandRepository.Update(book);
        await unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}