using Domain.Models.Course;
using Domain.Models.Lessons;

namespace Domain.Interfaces.Repositories;

public interface ICourse
{
    public Task Save(Course course, CancellationToken cancellationToken);
    public Task Delete(Guid id, CancellationToken cancellationToken);
    public Task<List<Course>> GetAllCourse(CancellationToken cancellationToken);
    public Task<Course> GetById(Guid id,CancellationToken cancellationToken);
    public Task<List<Lesson>> GetTasksByCourse(Guid id, CancellationToken cancellationToken);
}