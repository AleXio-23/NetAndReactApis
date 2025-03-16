using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Shared.Constants;

namespace NorthernLight.Auth.Persistence.DbContextValues.UserJobPositions
{
    public class JobPositionModelBuilder : IEntityTypeConfiguration<JobPosition>
    {
        public void Configure(EntityTypeBuilder<JobPosition> entity)
        {
            entity.ToTable("JobPositions", SchemaConstants.SCHEMA_DICTIONARY);
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Code).HasColumnType("VARCHAR(255)");
            entity.Property(x => x.Name).HasColumnType("NVARCHAR(255)");
            entity.Property(x => x.IsActive).HasDefaultValueSql("((1))");

        }
    }
}
