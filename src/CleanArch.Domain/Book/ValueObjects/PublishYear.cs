using CleanArch.Domain.Book.Errors;

namespace CleanArch.Domain.Book.ValueObjects;

public sealed record PublishYear
{
    // ReSharper disable once MemberCanBePrivate.Global
    public int Value { get; init; }

    private PublishYear(int value)
    {
        Value = value;
    }

    public static Result<PublishYear> Create(int value)
    {
        int currentYear = DateTime.UtcNow.Year;

        if (value <= 0)
            return PublishYearErrors.Invalid;

        if (value > currentYear)
            return PublishYearErrors.InFuture;

        return new PublishYear(value);
    }

    public override string ToString()
        => Value.ToString();
}