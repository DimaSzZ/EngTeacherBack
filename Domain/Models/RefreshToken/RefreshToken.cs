namespace Domain.Models.RefreshToken;

public class RefreshToken
{
    public Guid UserId { get; }
    public string Token { get; }
    public DateTime ExpiresAt { get; }
    public DateTime CreatedAt { get; }

    public bool Revoked { get; private set; }
    
    public User.User User { get; } = null!;
}