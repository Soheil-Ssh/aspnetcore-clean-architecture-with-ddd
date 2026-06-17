namespace CleanArch.Api.Contracts.Member.Requests;

public sealed record CreateMemberRequest(string FirstName, string LastName, string Email);