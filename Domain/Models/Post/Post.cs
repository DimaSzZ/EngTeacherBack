using Newtonsoft.Json;

namespace Domain.Models.Post;

public class Post
{
    public Post(Guid authorId, string description, string photo, Guid userId)
    {
        Id = Guid.NewGuid();
        AuthorId = authorId;
        Description = description;
        Photo = photo;
        PostedAt = DateTime.Now;
        UserId = userId;
    }

    public Guid Id { get; }
    [JsonIgnore] public Guid AuthorId { get; }
    public string Description { get; private set; }
    public string Photo { get; private set; }
    public DateTime PostedAt { get; }
    public Guid UserId { get;}


    [JsonIgnore] public virtual IEnumerable<User.User> Members { get; set; } = null!;
    [JsonIgnore] public User.User Creater { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Like.Like> Likes { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Comment.Comment> Comments { get; } = null!;

    public PostDetail ToDetail()
    {
        return new PostDetail(Id, Description, Photo, PostedAt, Creater.NickName, Likes.Count(), Comments.ToList());
    }

    public PostMiniature PostMiniature()
    {
        return new PostMiniature(Id, Description, Photo, PostedAt);
    }
}