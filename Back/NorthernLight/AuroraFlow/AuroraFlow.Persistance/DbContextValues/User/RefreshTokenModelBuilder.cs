using AuroraFlow.Persistance.Entities;
using AuroraFlow.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuroraFlow.Persistance.DbContextValues.User;

public class RefreshTokenModelBuilder : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> entity)
    { 
        entity.ToTable("RefreshTokens", SchemaConstants.SCHEMA_UMS);
        entity.HasKey(e => e.Id).HasName("PK__RefreshT__3214EC0742E1BF6C");

        entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
        entity.Property(e => e.Token).HasMaxLength(2000);

        entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK__RefreshTo__UserI__37A5467C");
    }
}