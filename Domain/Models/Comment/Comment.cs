using Newtonsoft.Json;

namespace Domain.Models.Comment;

public class Comment
{
    public Comment(string text, Guid userId, Guid postId)
    {
        Id = Guid.NewGuid();
        Text = text;
        UserId = userId;
        PostId = postId;
        CommentedAt = DateTime.Now;
    }

    public Guid Id { get; }
    public string Text { get; }
    public Guid UserId { get; }
    public Guid PostId { get; }
    public DateTime CommentedAt { get; }
    
    [JsonIgnore] public User.User User { get; } = null!;
    [JsonIgnore] public Post.Post Post { get; } = null!;

    public CourseMiniature ToMiniature()
    {
        return new CourseMiniature(Id,Text,CommentedAt,User.Avatar,User.NickName);
    }
}