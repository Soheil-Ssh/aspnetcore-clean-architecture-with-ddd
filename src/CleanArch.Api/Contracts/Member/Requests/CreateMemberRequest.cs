namespace CleanArch.Api.Contracts.Member.Requests;

public sealed record UpdateMemberRequest(string FirstName, string LastName, string Email);