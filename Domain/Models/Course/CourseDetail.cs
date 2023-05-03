using Domain.Models.Lessons;
using Domain.Models.User;

namespace Domain.Models.Course;

public record CourseDetail(
    Guid Id,
    string Name,
    string? Description,
    string Level,
    DateTime CreatedDate,
    DateTime ModifiedDate,
    Guid AuthorId,
    UserMiniature User,
    List<LessonMiniature> Lessons);