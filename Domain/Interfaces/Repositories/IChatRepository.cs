using Domain.Models.Chat;

namespace Domain.Interfaces.Repositories;

public interface IChat
{
    public Task Create(Chat user, CancellationToken cancellationToken);
    public Task Delete(Guid id, CancellationToken cancellationToken);
    
    public Task<List<Chat>> GetAllChat(Guid idSender,CancellationToken cancellationToken);
    public Task<Chat> GetChatById(Guid id,CancellationToken cancellationToken);
}