using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthernLight.Auth.Persistence.Entities;

namespace NorthernLight.Auth.Persistence.DbContextValues
{
    public class VwUserSignInResponseModelBuilder : IEntityTypeConfiguration<VwUserSignInResponse>
    {
        public void Configure(EntityTypeBuilder<VwUserSignInResponse> entity)
        {
            entity
              .HasNoKey()
              .ToView("vw_UserSignInResponse", "ums");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
        }
    }
}
