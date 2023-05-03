using Domain.Models.Lessons;
using Newtonsoft.Json;

namespace Domain.Models.Course;

public class Course
{
    public Course(string name, string description, string level, Guid authorId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Level = level;
        CreatedDate = DateTime.Now;
        ModifiedDate = DateTime.Now;
        AuthorId = authorId;
    }

    public Guid Id { get;}
    public string Name { get; set; }
    public string Description { get; set; }
    public string Level { get;}
    public DateTime CreatedDate { get; }
    public DateTime ModifiedDate { get; }
    public Guid AuthorId { get; }

    [JsonIgnore] public User.User User { get; set; } = null!;
    [JsonIgnore] public virtual IEnumerable<Lesson> Lessons { get; set; } = null!;

    public CourseMiniature ToMiniature()
    {
        return new CourseMiniature(Id,Name,Description,Level,CreatedDate);
    }

    public CourseDetail ToDetail()
    {
        return new CourseDetail(Id,Name,Description,Level,CreatedDate,ModifiedDate,AuthorId,User.ToMiniature(),Lessons.Select(x=>x.ToMiniature()).ToList());
    }
}