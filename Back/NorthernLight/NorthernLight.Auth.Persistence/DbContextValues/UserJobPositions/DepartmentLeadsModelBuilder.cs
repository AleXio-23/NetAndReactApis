using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Shared.Constants;

namespace NorthernLight.Auth.Persistence.DbContextValues.UserJobPositions
{
    internal class DepartmentLeadsModelBuilder : IEntityTypeConfiguration<DepartmentLeads>
    {
        public void Configure(EntityTypeBuilder<DepartmentLeads> entity)
        {
            entity.ToTable("DepartmentLeads", SchemaConstants.SCHEMA_UMS);

            entity.HasKey(e => e.Id);

            entity.HasIndex(e => new { e.UserId, e.DepartmentId }, "UQ__DepLeads__7D317271A0CD5621").IsUnique();
            entity.HasOne(x => x.Department)
                .WithMany(x => x.DepartmentLeads)
                .HasConstraintName("FK_DepLeads_ForDeps_02042024");

            entity.HasOne(x => x.User)
                .WithMany(x => x.DepartmentLeads)
                .HasConstraintName("FK_DepLeads_forUsers_02042024");
        }
    }
}
