using System.Text.Json.Serialization;

namespace Domain.Models.Dictionary;

public class Dictionary
{
    public Dictionary(Dictionary<string, string>? dictionarry)
    {
        Id = Guid.NewGuid();
        Dictionarry = dictionarry;
    }

    public Guid Id { get; set; }
    public Dictionary<string, string>? Dictionarry { get; set; }
    [JsonIgnore] public User.User User { get; } = null!;

    public DictionaryMiniature ToMiniature()
    {
        return new DictionaryMiniature(Id,Dictionarry,User.ToMiniature());
    }
}