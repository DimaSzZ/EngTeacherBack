using Domain.Models.Lessons;
using Newtonsoft.Json;

namespace Domain.Models.Course;

public class Course
{
    public Guid Id { get;}
    public string Name { get; set; }
    public string Description { get; set; }
    public string Level { get;}
    public DateTime CreatedDate { get; }
    public DateTime ModifiedDate { get; }
    public Guid AuthorId { get; }

    [JsonIgnore] public User.User User { get; set; } = null!;
    [JsonIgnore] public virtual IEnumerable<Lesson> Lessons { get; set; } = null!;
    
}