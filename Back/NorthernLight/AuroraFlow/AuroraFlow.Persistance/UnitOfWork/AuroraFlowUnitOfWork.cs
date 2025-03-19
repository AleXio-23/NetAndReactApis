using AuroraFlow.Persistance.Entities;
using AuroraFlow.Persistance.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace AuroraFlow.Persistance.UnitOfWork;

public class AuroraFlowUnitOfWork : IAuroraFlowUnitOfWork
{
    private readonly AuroraFlowDbContext _context;


    public AuroraFlowUnitOfWork(AuroraFlowDbContext context)
    {
        _context = context;
        Users = new GenericContextRepository<User>(_context);
        RefreshToken = new GenericContextRepository<RefreshToken>(_context);
    }

    public void Dispose()
    {   
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public async Task<int> CompleteAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public IRepository<User> Users { get; }
    public IRepository<RefreshToken> RefreshToken { get; }
}