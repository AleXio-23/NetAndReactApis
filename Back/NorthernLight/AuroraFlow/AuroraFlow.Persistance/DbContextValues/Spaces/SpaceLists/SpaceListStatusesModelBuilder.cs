using AuroraFlow.Persistance.Entities.Spaces.SpaceLists;
using AuroraFlow.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuroraFlow.Persistance.DbContextValues.Spaces.SpaceLists;

public class SpaceListStatusesModelBuilder : IEntityTypeConfiguration<SpaceListStatuses>
{
    public void Configure(EntityTypeBuilder<SpaceListStatuses> entity)
    {
        entity.ToTable("SpaceListStatuses", SchemaConstants.SCHEMA_SPACE);
        entity.HasKey(x => x.Id);

        entity.Property(e => e.Name)
            .IsRequired(false).HasColumnType("VARCHAR(255)");
        entity.Property(e => e.Color)
            .IsRequired(false).HasColumnType("VARCHAR(20)");
        entity.Property(e => e.SortIndex)
            .IsRequired(false);


        entity.HasOne(e => e.SpaceList)
            .WithMany(e => e.SpaceListStatuses)
            .HasForeignKey(f => f.SpaceListId);

        entity.HasOne(e => e.TaskStatusType)
            .WithMany(e => e.SpaceListStatuses)
            .HasForeignKey(f => f.TaskStatusType);
    }
}