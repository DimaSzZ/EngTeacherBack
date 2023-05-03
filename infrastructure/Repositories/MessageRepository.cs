using Domain.Interfaces.Repositories;
using Domain.Models.Message;
using infrastructure.Parsistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class MessageRepository : IMessage
{
    private readonly SupabaseDbContext _db;

    public MessageRepository(SupabaseDbContext db)
    {
        _db = db;
    }

    public async Task Save(Message message, CancellationToken cancellationToken)
    {
        if (_db.Messages.Contains(message))
        {
            _db.Update(message);
        }
        else
            await _db.Messages.AddAsync(message, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<Message> OneById(Guid message, CancellationToken cancellationToken)
    {
        return await _db.Messages.FirstAsync(x=>x.Id == message,cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        _db.Messages.Remove( await _db.Messages.FirstAsync(x=>x.Id==id,cancellationToken));
        await _db.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> IsExistById(Guid id, CancellationToken cancellationToken)
    {
        return _db.Messages.AnyAsync(x => x.Id == id, cancellationToken);
    }
}