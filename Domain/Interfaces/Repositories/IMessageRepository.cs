using Domain.Models.Message;

namespace Domain.Interfaces.Repositories;

public interface IMessage
{
    public Task Save(Message message, CancellationToken cancellationToken);
    public Task<Message> OneById(Guid message, CancellationToken cancellationToken);
    public Task Delete(Guid id, CancellationToken cancellationToken);
    public Task<bool> IsExistById(Guid id,CancellationToken cancellationToken);
}