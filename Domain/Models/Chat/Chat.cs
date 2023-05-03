using Newtonsoft.Json;

namespace Domain.Models.Chat;

public class Chat
{
    public Chat(Guid user1Id, Guid user2Id)
    {
        Id = Guid.NewGuid();
        IdSender = user1Id;
        IdRecipient = user2Id;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Guid Id { get; set; }
    public Guid IdSender { get;}
    public Guid IdRecipient { get;}
    public DateTime CreatedAt { get;}
    public DateTime UpdatedAt { get;}
    
    [JsonIgnore] public IEnumerable<Message.Message> Messages { get; set; }

    public ChatDetail ToDetail()
    {
        return new ChatDetail(Id,IdSender,IdRecipient,CreatedAt,UpdatedAt,Messages.Select(x=>x.ToMiniature()).ToList());
    }
}
