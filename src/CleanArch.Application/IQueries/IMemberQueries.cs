using CleanArch.Application.Features.Member.Common;

namespace CleanArch.Application.IQueries;

public interface IMemberQueries
{
    Task<MemberDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}