using Newtonsoft.Json;

namespace Domain.Models.Group;

public class Group
{
    public Group(string name, DateTime dateOfCreate, Guid createrId,string? description="")
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        DateOfCreate = dateOfCreate;
        CreaterId = createrId;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime DateOfCreate { get; set; }
    public Guid CreaterId { get; set; }

    public ICollection<string> MediaFiles { get; set; } = null!;
    
    [JsonIgnore] public virtual IEnumerable<User.User> Users { get; set; } = null!;
    [JsonIgnore] public virtual IEnumerable<Test.Test> Tests { get; set; } = null!;
    [JsonIgnore] public virtual IEnumerable<Message.Message> Message { get; set; } = null!;

    public GroupMiniature ToMiniature()
    {
        return new GroupMiniature(Id,Name,Description,CreaterId,Users.Select(x=>x.ToMiniature()).ToList());
    }
}