using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Persistence.Entities;

namespace NorthernLight.Auth.Persistence.DbContextValues
{

    public class UserProfileModelBuilder : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> entity)
        {
            entity.ToTable("UserProfile", "ums");
            entity.HasKey(x => x.Id).HasName("PK_UserProfileId_01022024");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Firstname).HasMaxLength(100);
            entity.Property(e => e.Lastname).HasMaxLength(100);
            entity.Property(e => e.PersonalNumber)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime2");


            entity.HasOne(d => d.User).WithOne(p => p.UserProfile)
                 .HasForeignKey<UserProfile>(d => d.UserId)
                 .HasConstraintName("FK__UserProfi__UserI__3E52440B");
        }
    }
}
