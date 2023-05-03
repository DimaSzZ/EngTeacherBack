using Domain.Models.Test;
using Newtonsoft.Json;

namespace Domain.Models.Task;

public class TaskModel
{
    public TaskModel(List<string> variants, string answer, Guid testId)
    {
        Id = Guid.NewGuid();
        Variants = variants;
        Answer = answer;
        TestId = testId;
    }

    public Guid Id { get; set; }
    public string TrueVariant { get; private set; }
    public List<string> Variants { get; private set; }
    public string Answer { get; private set; }
    public Guid TestId { get;}
    
    [JsonIgnore] public Test.Test Test { get; } = null!;

    public TaskMiniature ToMiniature()
    {
        return new TaskMiniature(Id,Variants,Answer,TrueVariant);
    }
}