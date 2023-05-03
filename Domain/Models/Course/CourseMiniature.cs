namespace Domain.Models.Course;

public record CourseMiniature(
    Guid Id,
    string Name,
    string? Description,
    string Level,
    DateTime CreatedDate 
    );