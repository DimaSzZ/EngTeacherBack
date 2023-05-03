using Domain.Models.User;

namespace Domain.Models.Dictionary;

public record DictionaryMiniature(
    Guid Id,
    Dictionary<string,string> Dictionary,
    UserMiniature UserMiniature);