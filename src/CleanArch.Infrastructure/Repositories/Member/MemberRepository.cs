using CleanArch.Domain.IRepositories.Member;

namespace CleanArch.Infrastructure.Repositories.Member;

public class MemberRepository(ApplicationDbContext context) : IMemberRepository
{
    public async Task AddAsync(Domain.Member.Member member, CancellationToken cancellationToken)
    {
        await context.Members.AddAsync(member, cancellationToken);
    }
}