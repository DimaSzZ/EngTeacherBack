using Newtonsoft.Json;

namespace Domain.Models.User;

public class User
{
    public Guid Id { get;}
    public string NickName { get; private set; }
    public string EMail { get; private set; }
    [JsonIgnore] public string? HashedPassword { get; private set; }
    public int PassedTests { get; private set; }
    public string Gender { get; private set; }
    public Guid DictionaryId { get; set; } 
    [JsonIgnore] public List<Guid> Followers { get; }
    [JsonIgnore] public List<Guid> Following { get; }
    [JsonIgnore] public DateTime CreatedAt { get; }
    [JsonIgnore] public Dictionary.Dictionary Dictionarry { get; set; }

    [JsonIgnore] public virtual IEnumerable<Course.Course> Courses { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Group.Group> Groups { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Post.Post> Posts { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Like.Like> Likes { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Comment.Comment> Comments { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Test.Test> Tests { get; } = null!;
}