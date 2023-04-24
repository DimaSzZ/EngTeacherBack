using Newtonsoft.Json;

namespace Domain.Models.Group;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateOfCreate { get; set; }
    public Guid CreaterId { get; set; }
    
    [JsonIgnore] public virtual IEnumerable<Admin.Admin> Admins { get; set; } = null!;
    [JsonIgnore] public virtual IEnumerable<User.User> Users { get; set; } = null!;
    [JsonIgnore] public virtual IEnumerable<Test.Test> Tests { get; set; } = null!;
}