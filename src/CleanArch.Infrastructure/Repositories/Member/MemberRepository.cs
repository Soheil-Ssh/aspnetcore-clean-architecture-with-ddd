using CleanArch.Domain.IRepositories.Member;
using CleanArch.Domain.Member.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Repositories.Member;

public class MemberRepository(ApplicationDbContext context) : IMemberRepository
{
    public async Task<Domain.Member.Member?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Members.FirstOrDefaultAsync(m => m.Id == new MemberId(id), cancellationToken);

    public async Task AddAsync(Domain.Member.Member member, CancellationToken cancellationToken)
    {
        await context.Members.AddAsync(member, cancellationToken);
    }

    public async Task<bool> IsExistByEmailAsync(string email, CancellationToken cancellationToken)
        => await context.Members.AnyAsync(m => m.Email.Value == email, cancellationToken);
}