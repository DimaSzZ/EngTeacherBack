using System.Text.Json.Serialization;

namespace Domain.Models.Dictionary;

public class Dictionary
{
    public Guid Id { get; set; }
    public Dictionary<string, string>? Dictionarry { get; set; }
    [JsonIgnore] public User.User User { get; } = null!;
}