using AuroraFlow.Persistance.DbContextValues.User;
using AuroraFlow.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuroraFlow.Persistance;

public partial class AuroraFlowDbContext : DbContext
{
    public AuroraFlowDbContext()
    {
    }

    public AuroraFlowDbContext(DbContextOptions<AuroraFlowDbContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserModelBuilder());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}