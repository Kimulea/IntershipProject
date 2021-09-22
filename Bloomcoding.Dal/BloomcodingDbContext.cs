using Bloomcoding.Dal.Constants;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bloomcoding.Domain.Auth;
using Bloomcoding.Domain;
using Bloomcoding.Dal.EntityConfiguration;

namespace Bloomcoding.Dal
{
    public class BloomcodingDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public BloomcodingDbContext(DbContextOptions<BloomcodingDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroupConfig).Assembly);

            ApplyIdentityMapConfiguration(modelBuilder);
        }

        private void ApplyIdentityMapConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", SchemaConstants.Auth);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims", SchemaConstants.Auth);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins", SchemaConstants.Auth);
            modelBuilder.Entity<UserToken>().ToTable("UserRoles", SchemaConstants.Auth);
            modelBuilder.Entity<Role>().ToTable("Roles", SchemaConstants.Auth);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", SchemaConstants.Auth);
            modelBuilder.Entity<UserRole>().ToTable("UserRole", SchemaConstants.Auth);
        }
    }
}
