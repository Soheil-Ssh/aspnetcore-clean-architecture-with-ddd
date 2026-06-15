namespace CleanArch.Domain.Book.Errors;

public class PublishYearErrors
{
    public static readonly Error Invalid = new("PublishYear.Invalid", "Publish year must be greater than zero.", ErrorType.Validation);
    public static readonly Error InFuture = new("PublishYear.InFuture", "Publish year cannot be in the future.", ErrorType.Validation);
}