using Newtonsoft.Json;

namespace Domain.Models.Like;

public class Like
{
    public Like(Guid userId, Guid postId, DateTime likedAt)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        PostId = postId;
        LikedAt = likedAt;
    }

    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid PostId { get; }
    public DateTime LikedAt { get; }
    
    [JsonIgnore] public User.User User { get; } = null!;
    [JsonIgnore] public Post.Post Post { get; } = null!;

    public LikeMiniature ToMiniature()
    {
        return new LikeMiniature(Id,UserId,PostId,LikedAt);
    }
}