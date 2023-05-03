using Domain.Interfaces.Accessors;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Storages;
using Domain.Interfaces.Utils.PasswordHasher;
using Domain.Interfaces.Utils.Tokens;
using Domain.Settings.Storages;
using Domain.Settings.Utils.PasswordHasher;
using Domain.Utils.File;
using infrastructure.Accessors;
using infrastructure.Parsistence;
using infrastructure.Repositories;
using infrastructure.Storages;
using infrastructure.Utils.File;
using infrastructure.Utils.PasswordHasher;
using infrastructure.Utils.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddUtils();
        services.AddRepositories();
        services.AddDb(configuration);
        services.AddIOptions(configuration);
        services.AddStorages(configuration);
        
        return services;
    }

    public static IServiceCollection AddUtils(
        this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher,PasswordHasher>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IAccessTokenService, AccessTokenService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<IAuthenticateService, AuthenticateService>();
        services.AddScoped<IUserAccessor, UserAccessor>();
        services.AddScoped<IFileUtils, FileUtils>();
        return services;
    }
    
    
    private static IServiceCollection AddStorages(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var settings = new SupabaseSettings();
        configuration.Bind(nameof(SupabaseSettings), settings);
        services.AddSingleton(settings);
        
        services.AddSingleton<ISupabaseStorage, SupabaseStorage>();

        return services;
    }

    private static IServiceCollection AddRepositories(
        this IServiceCollection services
    )
    {
        services.AddScoped<IChat,ChatRepository>();
        services.AddScoped<ICommentRepository,CommentRepository>();
        services.AddScoped<ICourse,CourseRepository>();
        services.AddScoped<IDictionary,DictionaryRepository>();
        services.AddScoped<IGroupRepository,GroupRepository>();
        services.AddScoped<ILesson,LessonRepository>();
        services.AddScoped<ILike,LikeRepository>();
        services.AddScoped<IMessage,MessageRepository>();
        services.AddScoped<IPostRepository,PostRepository>();
        services.AddScoped<IRefreshTokenRepository,RefreshTokenRepository>();
        services.AddScoped<ITaskRepository,TaskRepository>();
        services.AddScoped<ITestRepository,TestRepository>();
        services.AddScoped<IUserRepository,UserRepository>();
        
        return services;
    }
    
    private static IServiceCollection AddDb(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<SupabaseDbContext>(opt
            => opt.UseNpgsql(configuration.GetConnectionString("SupabaseCredentials")));
        return services;
    }
    
    private static IServiceCollection AddIOptions(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<HashingSettings>(configuration.GetSection(nameof(HashingSettings)));
        return services;
    }
}