namespace Domain.Models.Comment;

public record CourseMiniature(
    Guid Id,
    string Text,
    DateTime Date,
    string Avatar,
    string NickName
    );