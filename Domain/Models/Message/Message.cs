using Newtonsoft.Json;

namespace Domain.Models.Message;

public class Message
{
    public Message(Guid senderId, string text, DateTime createdAt, Guid chatId)
    {
        Id = Guid.NewGuid();
        SenderId = senderId;
        Text = text;
        CreatedAt = createdAt;
        ChatId = chatId;
    }

    public Guid Id { get;}
    public Guid SenderId { get; }
    public string Text { get; private set; }
    public DateTime CreatedAt { get; }
    public Guid ChatId { get;}
    [JsonIgnore] public Chat.Chat Chat { get; }

    public MessageMiniature ToMiniature()
    {
        return new MessageMiniature(Id,SenderId,Text,CreatedAt,ChatId);
    }
}