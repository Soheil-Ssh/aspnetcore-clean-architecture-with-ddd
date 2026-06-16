using System.Text.RegularExpressions;
using CleanArch.Domain.Book.Errors;

namespace CleanArch.Domain.Book.ValueObjects;

public sealed record Barcode
{
    private static readonly Regex Pattern = new(@"^LIB-\d{6}$", RegexOptions.Compiled);

    public string Value { get; init; }

    private Barcode(string value)
    {
        Value = value;
    }

    public static Result<Barcode> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return BarcodeErrors.Empty;

        value = value.Trim().ToUpperInvariant();

        if (!Pattern.IsMatch(value))
            return BarcodeErrors.InvalidFormat;

        return new Barcode(value);
    }

    public override string ToString()
        => Value;
}