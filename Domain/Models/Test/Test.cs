using Newtonsoft.Json;

namespace Domain.Models.Test;

public class Test
{
    public Guid Id { get;}
    public string Name { get; private set; }
    public string Mark { get; private set; }
    [JsonIgnore] public User.User User { get; } = null!;
    [JsonIgnore] public virtual IEnumerable<Task.Task> Tasks { get; } = null!;
}