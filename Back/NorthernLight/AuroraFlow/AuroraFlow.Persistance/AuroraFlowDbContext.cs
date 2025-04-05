using AuroraFlow.Persistance.DbContextValues.Dictionaries;
using AuroraFlow.Persistance.DbContextValues.Spaces;
using AuroraFlow.Persistance.DbContextValues.Spaces.SpaceLists;
using AuroraFlow.Persistance.DbContextValues.User;
using AuroraFlow.Persistance.Entities;
using AuroraFlow.Persistance.Entities.Dictionaries;
using AuroraFlow.Persistance.Entities.Spaces;
using AuroraFlow.Persistance.Entities.Spaces.SpaceLists;
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
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<TaskPriority> TaskPriorities { get; set; }
    public virtual DbSet<TaskStatusType> TaskStatusTypes { get; set; }
    public virtual DbSet<SpaceList> SpaceLists { get; set; }
    public virtual DbSet<SpaceListStatuses> SpaceListStatuses { get; set; }
    public virtual DbSet<WorkSpace> WorkSpace { get; set; }
    public virtual DbSet<WorkSpaceInvitedUsers> WorkSpaceInvitedUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserModelBuilder());
        modelBuilder.ApplyConfiguration(new RefreshTokenModelBuilder());
        modelBuilder.ApplyConfiguration(new TaskPriorityModelBuilder());
        modelBuilder.ApplyConfiguration(new TaskStatusTypeModelBuilder());
        modelBuilder.ApplyConfiguration(new SpaceListModelBuilder());
        modelBuilder.ApplyConfiguration(new SpaceListStatusesModelBuilder());
        modelBuilder.ApplyConfiguration(new WorkSpaceModelBuilder());
        modelBuilder.ApplyConfiguration(new WorkSpaceInvitedUsersModelBuilder());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}