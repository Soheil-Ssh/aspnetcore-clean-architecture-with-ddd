using CleanArch.Domain.Member;

namespace CleanArch.Infrastructure.Repositories;

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

    public async Task<bool> IsExistByEmailAsync(Guid id, string email, CancellationToken cancellationToken)
        => await context.Members.AnyAsync(m => m.Id != new MemberId(id) && m.Email.Value == email, cancellationToken);
}