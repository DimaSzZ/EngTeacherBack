using Newtonsoft.Json;

namespace Domain.Models.Lessons;

public class Lesson
{
    public Lesson(string title, string content, Guid authorId, Guid courseId, string? description = "")
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Content = content;
        CreatedDate = DateTime.Now;
        ModifiedDate = DateTime.Now;
        AuthorId = authorId;
        CourseId = courseId;
    }
    
    public Guid Id { get; set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedDate { get; }
    public DateTime ModifiedDate { get; }
    public Guid AuthorId { get; }
    public Guid CourseId { get; }
    
    [JsonIgnore] public Course.Course Course { get; set; } = null!;

    public LessonMiniature ToMiniature()
    {
        return new LessonMiniature(Id,Title,Description,Content,AuthorId);
    }
}