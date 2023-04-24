using Newtonsoft.Json;

namespace Domain.Models.Post;

public class Post
{
    public Guid Id { get; }
    [JsonIgnore] public Guid AuthorId { get; }
    public string Description { get; }
    public string Photo { get; }
    public DateTime PostedAt { get; }
    public Guid UserId { get;}
    
    
    [JsonIgnore] public User.User User { get; } = null!;
    [JsonIgnore] public IEnumerable<Like.Like> Likes { get; } = null!;
    [JsonIgnore] public IEnumerable<Comment.Comment> Comments { get; } = null!;
}