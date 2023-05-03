namespace Domain.Models.User;

public record UserMiniature(
    Guid Id,
    string Nickname,
    string? Avatar
    );