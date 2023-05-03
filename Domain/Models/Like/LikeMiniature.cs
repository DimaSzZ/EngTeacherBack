namespace Domain.Models.Like;

public record LikeMiniature(
    Guid Id,
    Guid UserId,
    Guid PostId,
    DateTime DateLike
    );