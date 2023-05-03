using Domain.Interfaces.Storages;
using Domain.Settings.Storages;
using infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Supabase;

namespace infrastructure.Storages;

public class SupabaseStorage : ISupabaseStorage
{
    private readonly SupabaseSettings _settings;

    public SupabaseStorage(SupabaseSettings settings)
    {
        _settings = settings;
    }
    public async Task<string?> Save(string adTitle, IFormFile file)
    {
        var supabase = new Client(_settings.Url, _settings.AnonKey);
        await supabase.InitializeAsync();
        var bucket = supabase.Storage.From("assets");
        var bytes = await file.GetBytes();
        var guid = Guid.NewGuid();
        var url = await bucket.Upload(bytes, $"{adTitle}/{guid}");
        return $"{_settings.Url}/storage/v1/object/public/{url}";
    }
}