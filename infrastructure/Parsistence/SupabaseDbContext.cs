using Domain.Models.Chat;
using Domain.Models.Comment;
using Domain.Models.Course;
using Domain.Models.Dictionary;
using Domain.Models.Group;
using Domain.Models.Lessons;
using Domain.Models.Like;
using Domain.Models.Message;
using Domain.Models.Post;
using Domain.Models.RefreshToken;
using Domain.Models.Task;
using Domain.Models.Test;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace infrastructure.Parsistence;

public class SupabaseDbContext: DbContext
{
    public SupabaseDbContext() : base()
    {
    }
    public SupabaseDbContext(DbContextOptions<SupabaseDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "../CleanAdArch.API/appsettings.json"))
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(),
                    $"../Api/appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json"),
                optional: true)
            // .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "../EngTeacher.Api/appsettings.json"))
            .Build();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Chat> Chats { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Dictionary> Dictionaries { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<Lesson> Lessons { get; set; } = null!;
    public DbSet<Like> Likes { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
    
    public DbSet<TaskModel> TaskModels { get; set; } = null!;
    public DbSet<Test> Tests { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
}