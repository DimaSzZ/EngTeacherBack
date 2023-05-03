using Domain.Models.Message;

namespace Domain.Models.Chat;

public record ChatDetail(
    Guid Id,
    Guid User1,
    Guid User2,
    DateTime DateCreate,
    DateTime DateUpdate,
    List<MessageMiniature> Messages);