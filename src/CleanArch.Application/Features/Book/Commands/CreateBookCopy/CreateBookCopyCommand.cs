namespace CleanArch.Application.Features.Book.Commands.CreateBookCopy;

public sealed record CreateBookCopyCommand(Guid BookId, string Barcode) : IRequest<Result<Guid>>;