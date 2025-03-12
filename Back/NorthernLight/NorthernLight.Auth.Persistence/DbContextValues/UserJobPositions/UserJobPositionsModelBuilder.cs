using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Shared.Constants;

namespace NorthernLight.Auth.Persistence.DbContextValues.UserJobPositions
{
    public class UserJobPositionsModelBuilder : IEntityTypeConfiguration<UserJobPosition>
    {
        public void Configure(EntityTypeBuilder<UserJobPosition> entity)
        {
            entity.ToTable("UserJobPositions", SchemaConstants.SCHEMA_UMS);

            entity.Property(e => e.StartDate).HasColumnType("datetime2").HasDefaultValueSql("(GETDATE())");
            entity.Property(e => e.EndDate).HasColumnType("datetime2");

            entity.HasKey(e => e.Id).HasName("PK__UserJobP__3214EC07006CED34");
            entity.HasIndex(e => new { e.UserId, e.PositionId, e.DepartmentId }, "UQ__UserJobP__7D317271A0CD5621")
                .IsUnique();

            entity.HasOne(d => d.Department).WithMany(p => p.UserJobPositions)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__UserJobPo__Depar__6FE99F9F");

            entity.HasOne(d => d.Position).WithMany(p => p.UserJobPositions)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__UserJobPo__Posit__6EF57B66");

            entity.HasOne(d => d.User).WithMany(p => p.UserJobPositions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserJobPo__UserI__6E01572D");
        }
    }
}