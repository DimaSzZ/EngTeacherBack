using Domain.Interfaces.Repositories;
using Domain.Models.User;
using infrastructure.Parsistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SupabaseDbContext _db;

    public UserRepository(SupabaseDbContext db)
    {
        _db = db;
    }

    public async Task Save(User user, CancellationToken cancellationToken)
    {
        if (_db.Users.Contains(user))
        {
            _db.Update(user);
        }
        else
            await _db.Users.AddAsync(user, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsWithEmail(string email, CancellationToken cancellationToken)
    {
        return await _db.Users.AnyAsync(user=>user.EMail == email, cancellationToken);
    }

    public async Task<bool> ExistsWithNickname(string nickname, CancellationToken cancellationToken)
    {
        return await _db.Users.AnyAsync(user=>user.NickName == nickname,cancellationToken);
    }

    public async Task<bool> ExistsWithId(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Users.AnyAsync(user=>user.Id == id, cancellationToken);
    }

    public async Task<User?> OneByEmail(string email, CancellationToken cancellationToken)
    {
        return await _db.Users.FirstAsync(user=>user.EMail == email,cancellationToken);
    }

    public async Task<User?> OneById(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Users.FirstAsync(user=>user.Id == id,cancellationToken);
    }

    public async Task AddUserToFriend(Guid followerId, Guid followingId,CancellationToken cancellationToken)
    {
        var follower = await _db.Users.FirstOrDefaultAsync(u => u.Id == followerId,cancellationToken);
        var following = await _db.Users.FirstOrDefaultAsync(u => u.Id == followingId,cancellationToken);
        if (follower != null && following != null)
        {
            follower.Following.Add(following.Id);
            following.Followers.Add(follower.Id);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}