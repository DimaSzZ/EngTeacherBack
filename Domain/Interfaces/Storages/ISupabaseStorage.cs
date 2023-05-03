using Microsoft.AspNetCore.Http;

namespace Domain.Interfaces.Storages;

public interface ISupabaseStorage
{
    public Task<string?> Save(string nickname, IFormFile file);
}