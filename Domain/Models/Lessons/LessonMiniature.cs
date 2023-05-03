namespace Domain.Models.Lessons;

public record LessonMiniature(
    Guid Id,
    string Title,
    string? Description,
    string Content,
    Guid AuthorId
    );