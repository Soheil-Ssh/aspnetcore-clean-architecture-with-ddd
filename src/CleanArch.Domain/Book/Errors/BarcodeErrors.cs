namespace CleanArch.Domain.Book.Errors;

public static class BarcodeErrors
{
    public static readonly Error Empty = new("Barcode.Empty", "Barcode cannot be empty.", ErrorType.Validation);
    public static readonly Error InvalidFormat = new("Barcode.InvalidFormat", "Barcode format is invalid, Barcode must match the format LIB-123456.", ErrorType.Validation);
}