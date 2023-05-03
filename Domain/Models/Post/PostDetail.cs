using Domain.Models.User;

namespace Domain.Models.Post;

public record PostDetail(
    Guid Id,
    string? Description,
    string? Photo,
    DateTime PostedAt,
    string NickName,
    int Likes,
    List<Comment.Comment> Comments);