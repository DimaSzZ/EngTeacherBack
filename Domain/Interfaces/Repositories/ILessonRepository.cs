using Domain.Models.Lessons;

namespace Domain.Interfaces.Repositories;

public interface ILesson
{
    public Task Save(Lesson lesson, CancellationToken cancellationToken);
    public Task Delete(Guid id, CancellationToken cancellationToken);
    public Task<bool> IsExistById(Guid id, CancellationToken cancellationToken);
    public Task<Lesson> OneById(Guid id, CancellationToken cancellationToken);
}