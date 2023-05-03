namespace Domain.Models.Message;

public record MessageMiniature(
    Guid Id,
    Guid SenderId,
    string Text,
    DateTime Date,
    Guid ChatId
    );