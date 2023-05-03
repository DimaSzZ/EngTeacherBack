using Domain.Models.User;

namespace Domain.Interfaces.Repositories;

public interface IUserRepository
{
    public Task Save(User user, CancellationToken cancellationToken);
    public Task<bool> ExistsWithEmail(string email, CancellationToken cancellationToken);
    public Task<bool> ExistsWithNickname(string nickname, CancellationToken cancellationToken);
    public Task<bool> ExistsWithId(Guid id, CancellationToken cancellationToken);
    public Task<User?> OneByEmail(string email, CancellationToken cancellationToken);
    public Task<User?> OneById(Guid id, CancellationToken cancellationToken);

    public Task AddUserToFriend(Guid followerId, Guid followingId,CancellationToken cancellationToken);
}