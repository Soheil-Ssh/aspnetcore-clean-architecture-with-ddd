using CleanArch.Domain.Book.Errors;

namespace CleanArch.Domain.Book.ValueObjects;

public sealed record Isbn
{
    // ReSharper disable once MemberCanBePrivate.Global
    public string Value { get; init; }

    private Isbn(string value)
    {
        Value = value;
    }

    public static Result<Isbn> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return IsbnErrors.Empty;

        string normalized = Normalize(value);

        if (normalized.Length is not (10 or 13))
            return IsbnErrors.InvalidLength;

        bool isValid = normalized.Length == 10
                ? IsValidIsbn10(normalized)
                : IsValidIsbn13(normalized);

        if (!isValid)
            return IsbnErrors.InvalidChecksum;

        return new Isbn(value);
    }

    private static bool IsValidIsbn10(string isbn)
    {
        if (!isbn[..9].All(char.IsDigit))
            return false;

        int sum = 0;

        for (int i = 0; i < 9; i++)
        {
            sum += (isbn[i] - '0') * (10 - i);
        }

        char lastChar = isbn[9];

        int checkDigit =
            lastChar == 'X'
                ? 10
                : char.IsDigit(lastChar)
                    ? lastChar - '0'
                    : -1;

        if (checkDigit < 0)
            return false;

        sum += checkDigit;

        return sum % 11 == 0;
    }

    private static bool IsValidIsbn13(string isbn)
    {
        if (!isbn.All(char.IsDigit))
            return false;

        int sum = 0;

        for (int i = 0; i < 12; i++)
        {
            int digit = isbn[i] - '0';

            sum += i % 2 == 0
                ? digit
                : digit * 3;
        }

        int expectedCheckDigit =
            (10 - (sum % 10)) % 10;

        int actualCheckDigit =
            isbn[12] - '0';

        return expectedCheckDigit ==
               actualCheckDigit;
    }

    private static string Normalize(string value)
        => value
            .Replace("-", "")
            .Replace(" ", "")
            .ToUpperInvariant();

    public override string ToString()
        => Value;
}