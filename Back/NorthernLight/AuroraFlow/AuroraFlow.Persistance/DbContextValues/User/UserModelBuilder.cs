using AuroraFlow.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuroraFlow.Persistance.DbContextValues.User;

public class UserModelBuilder : IEntityTypeConfiguration<Entities.User>
{
    public void Configure(EntityTypeBuilder<Entities.User> entity)
    {
        entity.ToTable("Users", SchemaConstants.SCHEMA_UMS);
        entity.HasKey(x => x.Id).HasName("PK_UserGuide_01022025");
        entity.Property(e => e.IsActive)
            .IsRequired()
            .HasDefaultValueSql("((1))");
    }
}