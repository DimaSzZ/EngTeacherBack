using Domain.Interfaces.Repositories;
using Domain.Models.Chat;
using infrastructure.Parsistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class ChatRepository : IChat
{
    private readonly SupabaseDbContext _db;
    public ChatRepository(SupabaseDbContext dbContext)
    {
        _db = dbContext;
    }

    public async Task Create(Chat chat, CancellationToken cancellationToken)
    {
         await _db.Chats.AddAsync(chat, cancellationToken);
         await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        _db.Chats.Remove(await _db.Chats.FirstAsync(x => x.Id == id,cancellationToken));
        await _db.SaveChangesAsync(cancellationToken);
    }

    public Task<List<Chat>> GetAllChat(Guid idSender,CancellationToken cancellationToken)
    {
        return _db.Chats.Where(x => x.IdSender == idSender).ToListAsync(cancellationToken);
    }

    public Task<Chat> GetChatById(Guid id, CancellationToken cancellationToken)
    {
        return _db.Chats.FirstAsync(x=>x.Id == id,cancellationToken);
    }
}