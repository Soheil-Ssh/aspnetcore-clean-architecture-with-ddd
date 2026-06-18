namespace CleanArch.Domain.Member;

public sealed record MemberId(Guid Value)
{
    public static MemberId New()
        => new(Guid.NewGuid());
}