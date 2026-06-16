using CleanArch.Domain.Book.Errors;
using CleanArch.Domain.Book.ValueObjects;

namespace CleanArch.Application.Features.Book.Commands.CreateBookCopy;

/// <summary>
/// Create book copy command
/// </summary>
/// <param name="bookRepository"></param>
/// <param name="unitOfWork"></param>
public sealed class CreateBookCopyCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateBookCopyCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateBookCopyCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetByIdAsync(request.BookId, cancellationToken);
        if (book is null) return BookErrors.NotFoundById;

        var barcodeResult = Barcode.Create(request.Barcode);
        if (barcodeResult.IsFailure) return barcodeResult.Error;

        var copyResult = book.AddCopy(barcodeResult.Data);
        if (copyResult.IsFailure) return copyResult.Error;

        await unitOfWork.SaveAsync(cancellationToken);
        return copyResult.Data;
    }
}