using Domain.Interfaces.Repositories;
using Domain.Models.Task;
using Domain.Models.Test;
using infrastructure.Parsistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class TestRepository : ITestRepository
{
    private readonly SupabaseDbContext _db;

    public TestRepository(SupabaseDbContext db)
    {
        _db = db;
    }

    public async Task Save(Test test, CancellationToken cancellationToken)
    {
        if (_db.Tests.Contains(test))
        {
            _db.Update(test);
        }
        else
            await _db.Tests.AddAsync(test, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Guid id,Guid createrId, CancellationToken cancellationToken)
    {
        var test = await _db.Tests.FirstAsync(x => x.Id == id, cancellationToken);
        if (test.UserId == createrId)
        {
            _db.Remove(test);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
    public async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Tests.AnyAsync(x => x.Id == id,cancellationToken);
    }

    public async Task<Test> OneById(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Tests.FirstAsync(x=>x.Id == id,cancellationToken);
    }

    public async Task<List<TaskModel>> GetAllTask(Guid id, CancellationToken cancellationToken)
    {
        return await _db.TaskModels.Where(x => x.Test.Id == id).ToListAsync(cancellationToken);
    }
}