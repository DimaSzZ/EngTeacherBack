using Domain.Interfaces.Repositories;
using Domain.Models.Like;
using infrastructure.Parsistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class LikeRepository : ILike
{
    private readonly SupabaseDbContext _db;

    public LikeRepository(SupabaseDbContext db)
    {
        _db = db;
    }

    public async Task<Like?> OneByPostAndUser(Guid userId, Guid postId, CancellationToken cancellationToken)
    {
        return await _db.Likes.Where(x => x.PostId == postId && x.UserId == userId).FirstAsync(cancellationToken);
    }

    public async Task<List<Like>> FindDetailsByPost(Guid postId, CancellationToken cancellationToken)
    {
        return await _db.Likes.Where(x => x.PostId == postId).ToListAsync(cancellationToken);
    }

    public async Task<string?> FirstNicknameByPost(Guid postId, CancellationToken cancellationToken)
    {
        var post = await _db.Posts.FirstAsync(x=>x.Id == postId,cancellationToken);
        var comment= post.Comments.MinBy(x=>Math.Abs((x.CommentedAt - post.PostedAt).Ticks));
        return comment?.User.NickName;
    }

    public async Task<int> CountByPost(Guid postId, CancellationToken cancellationToken)
    {
        return await _db.Likes.Where(x => x.PostId == postId).CountAsync(cancellationToken);
    }

    public async Task Save(Like like, CancellationToken cancellationToken)
    {
        await _db.Likes.AddAsync(like, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsWithPostAndUser(Guid userId, Guid postId, CancellationToken cancellationToken)
    {
        var zxc = await _db.Posts.FirstAsync(x=>x.Id == postId,cancellationToken);
        return zxc.Likes.Any(x => x.UserId == userId);
    }

    public async Task Delete(Like like, CancellationToken cancellationToken)
    {
        _db.Remove(like);
        await _db.SaveChangesAsync(cancellationToken);
    }
}