using EF02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF02.DbContexts
{
    internal class EventHubDbContexts : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\MICROSQL;Database=EventHub;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.EventConfiguration());

            #region Fluent API for OrganizerProfile
            modelBuilder.Entity<OrganizerProfile>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Biography).HasMaxLength(500);
                entity.Property(p => p.WebsiteUrl).HasMaxLength(250);
                entity.Property(p => p.LogoUrl).HasMaxLength(250);
            });
            #endregion
            #region Fluent API for Badge
            modelBuilder.Entity<Badge>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.BadgeNumber).IsRequired().HasMaxLength(50);
                entity.Property(b => b.Tier).IsRequired().HasMaxLength(20);
                entity.Property(b => b.IssueDate).IsRequired();
            });
            #endregion

            #region Relationships

            #region Relationship between Organizer and OrganizerProfile  => one to one
            modelBuilder.Entity<Organizer>()
            .HasOne(o => o.OrganizerProfile)
            .WithOne(p => p.Organizer)
            .HasForeignKey<OrganizerProfile>(p => p.OrganizerId);
            #endregion

            #region Relationship between Organizer and Events  => one to many
            modelBuilder.Entity<Organizer>()
            .HasMany(o => o.Events)
            .WithOne(e => e.Organizer)
            .HasForeignKey(e => e.OrganizerId);
            #endregion

            #region Relationship between Attendee and Badge  => one to one
            modelBuilder.Entity<Attendee>()
            .HasOne(a => a.Badge)
            .WithOne(b => b.Attendee)
            .HasForeignKey<Badge>(b => b.AttendeeId);
            #endregion
            #endregion



        }
    }
}
