using Domain.Interfaces.Repositories;
using Domain.Models.Lessons;
using infrastructure.Parsistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class LessonRepository : ILesson
{
    private readonly SupabaseDbContext _db;
    
    public LessonRepository(SupabaseDbContext db)
    {
        _db = db;
    }

    public async Task Save(Lesson lesson, CancellationToken cancellationToken)
    {
        if (_db.Lessons.Contains(lesson))
        {
            _db.Update(lesson);
        }
        else
            await _db.Lessons.AddAsync(lesson, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        _db.Remove(await _db.Lessons.FirstAsync(x => x.Id == id, cancellationToken));
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsExistById(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Lessons.AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Lesson> OneById(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Lessons.FirstAsync(x => x.Id == id, cancellationToken);
    }
}