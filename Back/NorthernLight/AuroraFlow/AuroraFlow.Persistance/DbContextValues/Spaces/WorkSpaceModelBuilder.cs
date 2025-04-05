using AuroraFlow.Persistance.Entities.Spaces;
using AuroraFlow.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuroraFlow.Persistance.DbContextValues.Spaces;

public class WorkSpaceModelBuilder : IEntityTypeConfiguration<WorkSpace>
{
    public void Configure(EntityTypeBuilder<WorkSpace> entity)
    {
        entity.ToTable("WorkSpace", SchemaConstants.SCHEMA_SPACE);
        entity.HasKey(x => x.Id);
        entity.Property(e => e.IconUrl)
            .IsRequired(false).HasColumnType("VARCHAR(255)");
        entity.Property(e => e.Title)
            .IsRequired().HasColumnType("NVARCHAR(1024)");
        entity.Property(e => e.IsPrivate)
            .IsRequired(true).HasDefaultValue(false);
    }
}