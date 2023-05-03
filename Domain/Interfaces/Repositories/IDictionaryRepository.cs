using Domain.Models.Dictionary;

namespace Domain.Interfaces.Repositories;

public interface IDictionary
{
    public Task Save(Dictionary dictionary, CancellationToken cancellationToken);
    public Task<Dictionary?> OneById(Guid id, CancellationToken cancellationToken);
}