using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Persistence.DbContextValues;
using NorthernLight.Auth.Persistence.DbContextValues.UserJobPositions;
using NorthernLight.Auth.Persistence.Entities;

namespace NorthernLight.Auth.Persistence
{
    public partial class AuthorizationDbContext : DbContext
    {
        public AuthorizationDbContext()
        {
        }

        public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<JobPosition> JobPositions { get; set; }
        public virtual DbSet<DepartmentLeads> DepartmentLeads { get; set; }
        public virtual DbSet<UserJobPosition> UserJobPosition { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserModelBuilder());
            modelBuilder.ApplyConfiguration(new UserProfileModelBuilder());
            modelBuilder.ApplyConfiguration(new RefreshTokenModelBuilder());
            modelBuilder.ApplyConfiguration(new VwUserSignInResponseModelBuilder());

            modelBuilder.ApplyConfiguration(new JobPositionModelBuilder());
            modelBuilder.ApplyConfiguration(new DepartmentModelBuilder());
            modelBuilder.ApplyConfiguration(new DepartmentLeadsModelBuilder());
            modelBuilder.ApplyConfiguration(new UserJobPositionsModelBuilder());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
