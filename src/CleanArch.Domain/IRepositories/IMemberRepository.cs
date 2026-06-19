namespace CleanArch.Domain.IRepositories;

public interface IMemberRepository
{
    Task<Member.Member?> GetByIdAsync(MemberId id, CancellationToken cancellationToken = default);
    Task AddAsync(Member.Member member, CancellationToken cancellationToken);
    Task<bool> IsExistByEmailAsync(string email, CancellationToken cancellationToken);
    Task<bool> IsExistByEmailAsync(MemberId id, string email, CancellationToken cancellationToken);
}