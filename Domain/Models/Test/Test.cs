using Newtonsoft.Json;

namespace Domain.Models.Test;

public class Test
{
    public Test(string name, string mark,Guid userId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Mark = mark;
        UserId = userId;
    }
    public Guid Id { get;}
    public string Name { get; private set; }
    public string Mark { get; private set; }
    
    public Guid UserId { get; }

    public TestMiniature TestMiniature()
    {
        return new TestMiniature(Id,Name,Mark,Tasks.Select(x=>x.ToMiniature()).ToList());
    }
    
    [JsonIgnore] public User.User User { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Task.TaskModel> Tasks { get; } = null!;
    
    [JsonIgnore] public virtual IEnumerable<Group.Group> Groups { get; } = null!;
}