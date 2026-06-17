namespace CleanArch.Domain.IRepositories.Member;

public interface IMemberRepository
{
    Task<Domain.Member.Member?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Domain.Member.Member member, CancellationToken cancellationToken);
    Task<bool> IsExistByEmailAsync(string email, CancellationToken cancellationToken);
}