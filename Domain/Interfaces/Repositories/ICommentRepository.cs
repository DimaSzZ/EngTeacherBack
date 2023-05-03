using Domain.Models.Comment;

namespace Domain.Interfaces.Repositories;

public interface ICommentRepository
{
    public Task<List<Comment>> FindByPost(Guid postId, CancellationToken cancellationToken);
    public Task Save(Comment comment, CancellationToken cancellationToken);
    
    public Task DeleteComment(Guid postId, Guid idComment, CancellationToken cancellationToken);
    
    public Task<Comment?> OneById(Guid id, CancellationToken cancellationToken);
}