using AuroraFlow.Persistance.Entities.Spaces;
using AuroraFlow.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuroraFlow.Persistance.DbContextValues.Spaces;

public class WorkSpaceInvitedUsersModelBuilder : IEntityTypeConfiguration<WorkSpaceInvitedUsers>
{
    public void Configure(EntityTypeBuilder<WorkSpaceInvitedUsers> entity)
    {
        entity.ToTable("WorkSpaceInvitedUsers", SchemaConstants.SCHEMA_SPACE);

        entity.HasOne(e => e.User)
            .WithMany(e => e.WorkSpaceInvitedUsers)
            .HasForeignKey(f => f.UserId);

        entity.HasOne(e => e.WorkSpace)
            .WithMany(e => e.WorkSpaceInvitedUsers)
            .HasForeignKey(f => f.WorkspaceId);
    }
}