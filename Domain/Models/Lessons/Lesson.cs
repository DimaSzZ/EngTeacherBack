using Newtonsoft.Json;

namespace Domain.Models.Lessons;

public class Lesson
{
    public Guid Id { get; set; }
    public string Title { get;}
    public string Description { get;}
    public string Content { get;}
    public DateTime CreatedDate { get; }
    public DateTime ModifiedDate { get; }
    public Guid AuthorId { get; }
    public Guid CourseId { get; }
    [JsonIgnore] public Course.Course Course { get; set; } = null!;
}