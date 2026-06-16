namespace CleanArch.Domain.Member.ValueObjects;

public sealed record MemberId(Guid Value)
{
    public static MemberId New()
        => new(Guid.NewGuid());
}