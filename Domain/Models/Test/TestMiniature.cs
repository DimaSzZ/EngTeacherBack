using Domain.Models.Task;

namespace Domain.Models.Test;

public record TestMiniature(
    Guid Id,
    string Name,
    string Mark,
    List<TaskMiniature> Tasks);