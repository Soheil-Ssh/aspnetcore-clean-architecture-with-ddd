namespace CleanArch.Domain.Common.Exceptions;

public class DomainException(Error.Error error) : Exception(error.Description)
{
    public Error.Error Error { get; } = error;
}