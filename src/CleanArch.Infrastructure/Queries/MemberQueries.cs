using CleanArch.Application.Features.Member.Common;
using CleanArch.Application.IQueries;
using CleanArch.Domain.Member.ValueObjects;

namespace CleanArch.Infrastructure.Queries;

public class MemberQueries(ApplicationDbContext context) : IMemberQueries
{
    public async Task<MemberDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await context.Members.AsNoTracking()
            .Where(m => m.Id == new MemberId(id))
            .Select(m => new MemberDto(m.Id.Value, m.FullName.ToString(), m.Email.Value, m.IsBlocked, m.MaxLoanCount, m.CreatedAt, m.UpdatedAt))
            .FirstOrDefaultAsync(cancellationToken);
}