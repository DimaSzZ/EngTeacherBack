using Domain.Interfaces.Repositories;
using Domain.Models.Group;
using Domain.Models.Test;
using Domain.Models.User;
using infrastructure.Parsistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly SupabaseDbContext _db;

    public GroupRepository(SupabaseDbContext db)
    {
        _db = db;
    }

    public async Task Save(Group user, CancellationToken cancellationToken)
    {
        if (_db.Groups.Contains(user))
        {
            _db.Update(user);
        }
        else
            await _db.Groups.AddAsync(user, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        _db.Remove(await _db.Groups.FirstAsync(x => x.Id == id, cancellationToken));
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsExistById(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Groups.AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Group?> OneById(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Groups.FirstAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<User>> GroupUsers(Guid idGroup, CancellationToken cancellationToken)
    {
        return await _db.Users.Where(x=>x.Groups.Any(g=>g.Id == idGroup)).ToListAsync(cancellationToken);
    }

    public async Task<List<Test>> AllTestsInGroup(Guid idGroup, CancellationToken cancellationToken)
    {
        return await _db.Tests.Where(x=>x.Groups.Any(g=>g.Id == idGroup)).ToListAsync(cancellationToken);
    }
}