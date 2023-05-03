using Newtonsoft.Json;

namespace Domain.Models.User;

public class User
{
    public User(
        string nickName,
        string eMail,
        string? hashedPassword = null,
        string gender = ""
    )
    {
        Id = Guid.NewGuid();
        NickName = nickName;
        EMail = eMail;
        HashedPassword = hashedPassword;
        Gender = gender;
        Followers = new List<Guid>();
        Following = new List<Guid>();
        CreatedAt = DateTime.Now;
    }
    
    public Guid Id { get;}
    public string NickName { get; private set; }
    public string EMail { get; private set; }
    
    public string? Avatar { get; private set; }
    [JsonIgnore] public string? HashedPassword { get; private set; }
    public int PassedTests { get; private set; }
    public string Gender { get; private set; }
    public Guid DictionaryId { get; set; }
    public int UnreadmMssages { get; set; }
    [JsonIgnore] public List<Guid> Followers { get; }
    [JsonIgnore] public List<Guid> Following { get; }
    [JsonIgnore] public DateTime CreatedAt { get; }
    [JsonIgnore] public Dictionary.Dictionary Dictionarry { get; set; }

    [JsonIgnore] public virtual IEnumerable<Course.Course> Courses { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Group.Group> Groups { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Post.Post> Posts { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Comment.Comment> Comments { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Test.Test> Tests { get; } = null!;
    public void UpdatePassword(string hash)
    {
        HashedPassword = hash;
    }
    public void Update(
        string nickname,
        string email,
        string? description,
        string? gender
    )
    {
        NickName = nickname;
        EMail = email;
        Gender = gender ?? string.Empty;
    }
    public void SetAvatar(string avatar)
    {
        Avatar = avatar;
    }
    public UserMiniature ToMiniature()
    {
        return new UserMiniature(Id, NickName, Avatar);
    }
}