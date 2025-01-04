using System;
using event_management_system.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace event_management_system.Server.DbManage
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary keys
            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Attendee>().HasKey(a => a.AttendeeId);

            // Configure relationships
            modelBuilder.Entity<Event>()
                .HasMany(e => e.Attendee)
                .WithOne(a => a.Event)
                .HasForeignKey(a => a.EventId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
