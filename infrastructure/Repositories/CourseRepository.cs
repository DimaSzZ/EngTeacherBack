using Domain.Interfaces.Repositories;
using Domain.Models.Course;
using Domain.Models.Lessons;
using infrastructure.Parsistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class CourseRepository : ICourse
{
    private readonly SupabaseDbContext _db;

    public CourseRepository(SupabaseDbContext db)
    {
        _db = db;
    }

    public async Task Save(Course course, CancellationToken cancellationToken)
    {
        if (_db.Courses.Contains(course))
        {
            _db.Update(course);
        }
        else
            await _db.Courses.AddAsync(course, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        _db.Remove(await _db.Courses.FirstAsync(x => x.Id == id, cancellationToken));
    }

    public async Task<List<Course>> GetAllCourse(CancellationToken cancellationToken)
    {
        return await _db.Courses.ToListAsync(cancellationToken);
    }

    public async Task<Course> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Courses.FirstAsync(x=>x.Id == id,cancellationToken);
    }


    public async Task<List<Lesson>> GetTasksByCourse(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Lessons.Where(x => x.CourseId == id).ToListAsync(cancellationToken);
    }
}