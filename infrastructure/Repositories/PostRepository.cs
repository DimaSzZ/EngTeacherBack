using Domain.Interfaces.Repositories;
using Domain.Models.Post;
using infrastructure.Parsistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly SupabaseDbContext _db;

    public PostRepository(SupabaseDbContext db)
    {
        _db = db;
    }

    public async Task<int> CountByUser(Guid user, Guid postId, CancellationToken cancellationToken)
    {
        var post = await _db.Posts.FirstAsync(x=>x.Id == postId,cancellationToken);
        return post.Members.Count();
    }

    public async Task Save(Post post, CancellationToken cancellationToken)
    {
        if (_db.Posts.Contains(post))
        {
            _db.Update(post);
        }
        else
            await _db.Posts.AddAsync(post, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<Post?> OneById(Guid id, CancellationToken cancellationToken)
    {
       return await _db.Posts.FirstAsync(x=>x.Id == id,cancellationToken);
    }

    public async Task<List<Post>> FindForFeed(List<Guid> users, DateTime? cursor, int take, CancellationToken cancellationToken)
    {
        return await _db
            .Posts
            .Where(post => users.Contains(post.AuthorId))
            .OrderByDescending(post => post.PostedAt)
            .Where(post => cursor == null || DateTime.Compare(post.PostedAt, (DateTime) cursor) < 0)
            .Take(take)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> ExistsWithId(Guid postId, CancellationToken cancellationToken)
    {
        return await _db.Posts.AnyAsync(post => post.Id == postId, cancellationToken);
    }
}