using AuroraFlow.Persistance.Entities;
using AuroraFlow.Persistance.Entities.Dictionaries;
using AuroraFlow.Persistance.Entities.Spaces;
using AuroraFlow.Persistance.Entities.Spaces.SpaceLists;
using AuroraFlow.Persistance.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace AuroraFlow.Persistance.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    int Complete();
    Task<int> CompleteAsync(CancellationToken cancellationToken);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}

public interface IAuroraFlowUnitOfWork : IUnitOfWork
{
    IRepository<User> Users { get; }
    IRepository<RefreshToken> RefreshToken { get; } 
    public IRepository<TaskPriority> TaskPriorities { get; }
    public IRepository<TaskStatusType> TaskStatusTypes { get; }
    public IRepository<SpaceList> SpaceLists { get; }
    public IRepository<SpaceListStatuses> SpaceListStatuses { get; }
    public IRepository<WorkSpace> WorkSpaces { get; }
    public IRepository<WorkSpaceInvitedUsers> WorkSpaceInvitedUsers { get; }
}