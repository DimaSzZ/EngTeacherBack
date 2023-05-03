using Domain.Interfaces.Repositories;
using Domain.Models.Task;
using infrastructure.Parsistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly SupabaseDbContext _db;

    public TaskRepository(SupabaseDbContext db)
    {
        _db = db;
    }
    public async Task Save(TaskModel task, CancellationToken cancellationToken)
    {
        if (_db.TaskModels.Contains(task))
        {
            _db.Update(task);
        }
        else
            await _db.TaskModels.AddAsync(task, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        _db.TaskModels.Remove(await _db.TaskModels.FirstAsync(x=>x.Id == id,cancellationToken));
    }

    public async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
    {
        return await _db.TaskModels.AnyAsync(x=>x.Id == id,cancellationToken);
    }

    public async Task<TaskModel> OneById(Guid id, CancellationToken cancellationToken)
    {
        return await _db.TaskModels.FirstAsync(x=>x.Id == id,cancellationToken);
    }
}