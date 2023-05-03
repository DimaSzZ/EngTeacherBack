using Domain.Interfaces.Repositories;
using Domain.Models.Comment;
using infrastructure.Parsistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly SupabaseDbContext _db;

    public CommentRepository(SupabaseDbContext db)
    {
        _db = db;
    }

    public async Task<List<Comment>> FindByPost(Guid postId, CancellationToken cancellationToken)
    {
        return await _db.Comments.Where(x => x.PostId == postId).ToListAsync(cancellationToken);
    }

    public async Task Save(Comment comment, CancellationToken cancellationToken)
    {
        if (_db.Comments.Contains(comment))
        {
            _db.Update(comment);
        }
        else
            await _db.Comments.AddAsync(comment, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteComment(Guid postId,Guid idComment, CancellationToken cancellationToken)
    {
       _db.Remove(await _db.Comments.FirstAsync(x => x.PostId == postId && x.Id == idComment, cancellationToken));
       await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<Comment?> OneById(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Comments.FirstAsync(x=>x.Id == id,cancellationToken);
    }
}