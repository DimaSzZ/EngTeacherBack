using Newtonsoft.Json;

namespace Domain.Models.Task;

public class Task
{
    public Guid Id { get; set; }
    public List<string> Variants { get; set; }
    public string Answer { get; set; }
    public Guid TestId { get; set; }
    [JsonIgnore] public Test.Test Test { get; } = null;
}