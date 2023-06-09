﻿using Domain.Models.Like;

namespace Domain.Interfaces.Repositories;

public interface ILike
{
    public Task<Like?> OneByPostAndUser(Guid userId, Guid postId, CancellationToken cancellationToken);
    public Task<List<Like>> FindDetailsByPost(Guid postId, CancellationToken cancellationToken);
    public Task<string?> FirstNicknameByPost(Guid postId, CancellationToken cancellationToken);
    public Task<int> CountByPost(Guid postId, CancellationToken cancellationToken);
    public Task Save(Like like, CancellationToken cancellationToken);
    public Task<bool> ExistsWithPostAndUser(Guid userId, Guid postId, CancellationToken cancellationToken);
    public Task Delete(Like like, CancellationToken cancellationToken);
}