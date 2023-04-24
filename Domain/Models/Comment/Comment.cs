using Newtonsoft.Json;

namespace Domain.Models.Comment;

public class Comment
{
    public string Text { get; }
    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid PostId { get; }
    public DateTime CommentedAt { get; }
    
    [JsonIgnore] public User.User User { get; } = null!;
    [JsonIgnore] public Post.Post Post { get; } = null!;
}