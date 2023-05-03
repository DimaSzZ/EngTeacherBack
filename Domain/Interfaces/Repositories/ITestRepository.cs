using Domain.Models.Test;

namespace Domain.Interfaces.Repositories;

public interface ITestRepository
{
    public Task Save(Test test, CancellationToken cancellationToken);
    public Task Delete(Guid id,Guid createrId, CancellationToken cancellationToken);
    public Task<bool> IsExist(Guid id, CancellationToken cancellationToken);
    public Task<Test> OneById(Guid id, CancellationToken cancellationToken);
    public Task<List<Models.Task.TaskModel>> GetAllTask(Guid id, CancellationToken cancellationToken);
}