using CleanArch.Domain.Common.Exceptions;
using CleanArch.Domain.Loan.Events;

namespace CleanArch.Application.Features.Loan.EventHandlers;

public sealed class LoanCreatedDomainEventHandler(IBookRepository bookRepository) : INotificationHandler<LoanCreatedDomainEvent>
{
    public async Task Handle(LoanCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetByIdAsync(notification.BookId ,cancellationToken);
        if (book is null) throw new DomainException(BookErrors.NotFoundById);

        var borrowResult = book.BorrowCopy(notification.BookCopyId);
        if (borrowResult.IsFailure) throw new DomainException(borrowResult.Error);
    }
}