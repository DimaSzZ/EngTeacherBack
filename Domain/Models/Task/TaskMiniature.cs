namespace Domain.Models.Task;

public record TaskMiniature(
    Guid Id,
    List<string> Variants,
    string Answer,
    string TrueVariant
    );