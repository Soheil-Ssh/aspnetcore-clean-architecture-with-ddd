
namespace CleanArch.Domain.Book.Errors;

public static class IsbnErrors
{
    public static readonly Error Empty = new("Isbn.Empty", "ISBN cannot be empty.", ErrorType.Validation);
    public static readonly Error InvalidLength = new("Isbn.InvalidLength", "ISBN must contain 10 or 13 digits.", ErrorType.Validation);
    public static readonly Error InvalidChecksum = new("Isbn.InvalidChecksum", "ISBN checksum is invalid.", ErrorType.Validation);
}