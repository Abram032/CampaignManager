using CampaignManager.App.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignManager.App.Data
{
    public class UserDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public UserDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<ApplicationUser>().Property(p => p.Id).HasMaxLength(128);
            modelBuilder.Entity<ApplicationUser>().Property(p => p.NormalizedEmail).HasMaxLength(128);
            modelBuilder.Entity<ApplicationUser>().Property(p => p.NormalizedUserName).HasMaxLength(128);

            modelBuilder.Entity<IdentityRole>().Property(p => p.Id).HasMaxLength(128);
            modelBuilder.Entity<IdentityRole>().Property(p => p.NormalizedName).HasMaxLength(128);

            modelBuilder.Entity<IdentityUserToken<string>>().Property(p => p.LoginProvider).HasMaxLength(128);
            modelBuilder.Entity<IdentityUserToken<string>>().Property(p => p.UserId).HasMaxLength(128);
            modelBuilder.Entity<IdentityUserToken<string>>().Property(p => p.Name).HasMaxLength(128);

            modelBuilder.Entity<IdentityUserRole<string>>().Property(p => p.UserId).HasMaxLength(128);
            modelBuilder.Entity<IdentityUserRole<string>>().Property(p => p.RoleId).HasMaxLength(128);

            modelBuilder.Entity<IdentityUserLogin<string>>().Property(p => p.LoginProvider).HasMaxLength(128);
            modelBuilder.Entity<IdentityUserLogin<string>>().Property(p => p.ProviderKey).HasMaxLength(128);
            modelBuilder.Entity<IdentityUserLogin<string>>().Property(p => p.UserId).HasMaxLength(128);

            modelBuilder.Entity<IdentityUserClaim<string>>().Property(p => p.Id).HasMaxLength(128);
            modelBuilder.Entity<IdentityUserClaim<string>>().Property(p => p.UserId).HasMaxLength(128);

            modelBuilder.Entity<IdentityRoleClaim<string>>().Property(p => p.Id).HasMaxLength(128);
            modelBuilder.Entity<IdentityRoleClaim<string>>().Property(p => p.RoleId).HasMaxLength(128);
        }
    }
}
