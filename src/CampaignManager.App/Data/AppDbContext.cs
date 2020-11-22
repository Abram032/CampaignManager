using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CampaignManager.Models;

namespace CampaignManager.App.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coalition> Coalitions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
 
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Item> Items { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(p => p.Id);
            modelBuilder.Entity<Category>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().Property(p => p.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Coalition>().HasKey(p => p.Id);
            modelBuilder.Entity<Coalition>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Coalition>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Coalition>().Property(p => p.Color).HasMaxLength(7).IsRequired(false);

            modelBuilder.Entity<Country>().HasKey(p => p.Id);
            modelBuilder.Entity<Country>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Country>().Property(p => p.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Object>().HasKey(p => p.Id);
            modelBuilder.Entity<Object>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Object>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Object>().Property(p => p.Type).IsRequired();
            modelBuilder.Entity<Object>().HasOne(p => p.Category).WithMany().IsRequired(false);
            modelBuilder.Entity<Object>().HasOne(p => p.Subcategory).WithMany().IsRequired(false);

            modelBuilder.Entity<Service>().HasKey(p => p.Id);
            modelBuilder.Entity<Service>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Service>().Property(p => p.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Status>().HasKey(p => p.Id);
            modelBuilder.Entity<Status>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Status>().Property(p => p.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Subcategory>().HasKey(p => p.Id);
            modelBuilder.Entity<Subcategory>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Subcategory>().Property(p => p.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Campaign>().HasKey(p => p.Id);
            modelBuilder.Entity<Campaign>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Campaign>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Campaign>().Property(p => p.Abbreviation).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Campaign>().Property(p => p.Description).HasMaxLength(10000).IsRequired(false);
            modelBuilder.Entity<Campaign>().Property(p => p.Currency).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Campaign>().Property(p => p.StartDate).IsRequired();
            modelBuilder.Entity<Campaign>().Property(p => p.EndDate).IsRequired(false);
            modelBuilder.Entity<Campaign>().Property(p => p.IsActive).IsRequired();
            modelBuilder.Entity<Campaign>().HasMany(p => p.Factions).WithOne(p => p.Campaign);

            modelBuilder.Entity<Location>().HasKey(p => p.Id);
            modelBuilder.Entity<Location>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Location>().Property(p => p.Description).HasMaxLength(500);
            modelBuilder.Entity<Location>().Property(p => p.Longitude).IsRequired(false);
            modelBuilder.Entity<Location>().Property(p => p.Latitude).IsRequired(false);
            modelBuilder.Entity<Location>().HasOne(p => p.Status).WithMany().IsRequired(false);
            modelBuilder.Entity<Location>().HasMany(p => p.Services).WithOne().IsRequired(false);
            modelBuilder.Entity<Location>().HasMany(p => p.Items).WithOne(p => p.Location);
            modelBuilder.Entity<Location>().HasOne(p => p.Faction).WithMany(p => p.Locations);
            modelBuilder.Entity<Location>().HasOne(p => p.Campaign).WithMany().IsRequired();

            modelBuilder.Entity<Mission>().HasKey(p => p.Id);
            modelBuilder.Entity<Mission>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Mission>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Mission>().Property(p => p.Description).HasMaxLength(10000);
            modelBuilder.Entity<Mission>().Property(p => p.StartDate).IsRequired();
            modelBuilder.Entity<Mission>().Property(p => p.EndDate).IsRequired(false);
            modelBuilder.Entity<Mission>().Property(p => p.IsActive).IsRequired();
            modelBuilder.Entity<Mission>().HasOne(p => p.Faction).WithMany().IsRequired();
            modelBuilder.Entity<Mission>().HasOne(p => p.Campaign).WithMany().IsRequired();
            modelBuilder.Entity<Mission>().HasMany(p => p.Objectives).WithOne();

            modelBuilder.Entity<Objective>().HasKey(p => p.Id);
            modelBuilder.Entity<Objective>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Objective>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Objective>().Property(p => p.Description).HasMaxLength(500);
            modelBuilder.Entity<Objective>().Property(p => p.Completed).IsRequired();

            modelBuilder.Entity<Faction>().HasKey(p => p.Id);
            modelBuilder.Entity<Faction>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Faction>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Faction>().Property(p => p.Budget).IsRequired();
            modelBuilder.Entity<Faction>().HasOne(p => p.Campaign).WithMany(p => p.Factions).IsRequired();
            modelBuilder.Entity<Faction>().HasOne(p => p.Coalition).WithMany().IsRequired();
            modelBuilder.Entity<Faction>().HasOne(p => p.Country).WithMany().IsRequired();
            modelBuilder.Entity<Faction>().HasMany(p => p.Locations).WithOne(p => p.Faction);
            modelBuilder.Entity<Faction>().HasMany(p => p.Missions).WithOne(p => p.Faction);

            modelBuilder.Entity<Item>().HasKey(p => p.Id);
            modelBuilder.Entity<Item>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Item>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Item>().Property(p => p.AvailableAt).IsRequired(false);
            modelBuilder.Entity<Item>().Property(p => p.Count).IsRequired();
            modelBuilder.Entity<Item>().HasOne(p => p.Campaign).WithMany().IsRequired();
            modelBuilder.Entity<Item>().HasOne(p => p.Location).WithMany(p => p.Items).IsRequired();
            modelBuilder.Entity<Item>().HasOne(p => p.Object).WithMany().IsRequired();
            modelBuilder.Entity<Item>().HasOne(p => p.Status).WithMany().IsRequired(false);
            modelBuilder.Entity<Item>().HasOne(p => p.Faction).WithMany().IsRequired();
        }
    }
}
