using AuroraFlow.Persistance.Entities;
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
}