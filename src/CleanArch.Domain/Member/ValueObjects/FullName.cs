using CleanArch.Domain.Member.Errors;

namespace CleanArch.Domain.Member.ValueObjects;

public sealed record FullName
{
    // ReSharper disable once MemberCanBePrivate.Global
    public string FirstName { get; init; }
    // ReSharper disable once MemberCanBePrivate.Global
    public string LastName { get; init; }

    private FullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Result<FullName> Create(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return FullNameErrors.FirstNameEmpty;

        if (string.IsNullOrWhiteSpace(lastName))
            return FullNameErrors.LastNameEmpty;

        firstName = firstName.Trim();
        lastName = lastName.Trim();

        if (firstName.Length > 100)
            return FullNameErrors.FirstNameTooLong;

        if (lastName.Length > 100)
            return FullNameErrors.LastNameTooLong;

        return new FullName(firstName, lastName);
    }

    public override string ToString()
        => FirstName + " " + LastName;
}