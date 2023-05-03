using Domain.Models.User;

namespace Domain.Models.Group;

public record GroupMiniature(
    Guid Id,
    string Name,
    string Description,
    Guid CreateId,
    List<UserMiniature> Users);