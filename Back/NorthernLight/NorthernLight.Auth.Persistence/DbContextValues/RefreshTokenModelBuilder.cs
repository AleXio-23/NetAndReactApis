using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthernLight.Auth.Persistence.Entities;

namespace NorthernLight.Auth.Persistence.DbContextValues
{
    public class RefreshTokenModelBuilder : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> entity)
        {

            entity.HasKey(e => e.Id).HasName("PK__RefreshT__3214EC0742E1BF6C");

            entity.ToTable("RefreshTokens", "ums");

            entity.Property(e => e.ExpiryDate).HasColumnType("datetime2");
            entity.Property(e => e.Token).HasMaxLength(2000);

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__RefreshTo__UserI__37A5467C");

        }
    }
}
