using Domain.Models.Group;
using Domain.Models.Test;
using Domain.Models.User;

namespace Domain.Interfaces.Repositories;

public interface IGroupRepository
{
    public Task Save(Group user, CancellationToken cancellationToken);
    public Task Delete(Guid id, CancellationToken cancellationToken);
    public Task<bool> IsExistById(Guid id, CancellationToken cancellationToken);
    public Task<Group?> OneById(Guid id, CancellationToken cancellationToken);
    public Task<List<User>> GroupUsers(Guid idGroup,CancellationToken cancellationToken);
    public Task<List<Test>> AllTestsInGroup(Guid idGroup,CancellationToken cancellationToken);
}