using Domain.Interfaces.Repositories;
using Domain.Models.Dictionary;
using infrastructure.Parsistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositories;

public class DictionaryRepository : IDictionary
{
    private readonly SupabaseDbContext _db;

    public DictionaryRepository(SupabaseDbContext db)
    {
        _db = db;
    }

    public async Task Save(Dictionary dictionary, CancellationToken cancellationToken)
    {
        if (_db.Dictionaries.Contains(dictionary))
        {
            _db.Update(dictionary);
        }
        else
            await _db.Dictionaries.AddAsync(dictionary, cancellationToken);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<Dictionary?> OneById(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Dictionaries.FirstAsync(x=>x.Id == id,cancellationToken);
    }
}