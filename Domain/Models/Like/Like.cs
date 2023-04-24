﻿using Newtonsoft.Json;

namespace Domain.Models.Like;

public class Like
{
    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid PostId { get; }
    public DateTime LikedAt { get; }
    
    [JsonIgnore] public User.User User { get; } = null!;
    [JsonIgnore] public Post.Post Post { get; } = null!;
}