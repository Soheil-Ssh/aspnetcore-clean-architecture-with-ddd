namespace CleanArch.Domain.IRepositories.Member;

public interface IMemberRepository
{
    Task AddAsync(Domain.Member.Member member, CancellationToken cancellationToken);
    Task<bool> IsExistByEmailAsync(string email, CancellationToken cancellationToken);
}