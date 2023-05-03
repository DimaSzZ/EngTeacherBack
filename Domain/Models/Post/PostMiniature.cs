namespace Domain.Models.Post;

public record PostMiniature(
    Guid Id,
    string Description,
    string? Photo,
    DateTime PostedAt
    );