namespace CleanArch.Domain.IRepositories;

public interface IMemberRepository
{
    Task<Member.Member?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Member.Member member, CancellationToken cancellationToken);
    Task<bool> IsExistByEmailAsync(string email, CancellationToken cancellationToken);
    Task<bool> IsExistByEmailAsync(Guid id, string email, CancellationToken cancellationToken);
}