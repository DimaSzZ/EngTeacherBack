using Domain.Models.Task;

namespace Domain.Interfaces.Repositories;

public interface ITaskRepository
{
    public Task Save(TaskModel task, CancellationToken cancellationToken);
    public Task Delete(Guid id, CancellationToken cancellationToken);
    public Task<bool> IsExist(Guid id, CancellationToken cancellationToken);
    public Task<TaskModel> OneById(Guid id, CancellationToken cancellationToken);
}