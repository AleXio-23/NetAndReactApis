using AuroraFlow.Persistance.Entities.Spaces.SpaceLists;
using AuroraFlow.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuroraFlow.Persistance.DbContextValues.Spaces.SpaceLists;

public class SpaceListModelBuilder : IEntityTypeConfiguration<SpaceList>
{
    public void Configure(EntityTypeBuilder<SpaceList> entity)
    {
        entity.ToTable("SpaceList", SchemaConstants.SCHEMA_SPACE);
        entity.HasKey(x => x.Id);
        entity.Property(e => e.Name)
            .IsRequired(false).HasColumnType("VARCHAR(255)");

        entity.Property(e => e.SortIndex)
            .IsRequired(false);
        entity.Property(e => e.IsActive)
            .IsRequired(true).HasDefaultValue(true);
        entity.Property(e => e.IsPrivate)
            .IsRequired(true).HasDefaultValue(false);

        entity.HasOne(e => e.WorkSpace)
            .WithMany(e => e.SpaceLists)
            .HasForeignKey(f => f.WorkSpaceId);
    }
}