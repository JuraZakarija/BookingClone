using System;
using System.Linq;
using BookingClone.Extensions;
using BookingClone.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingClone.DB
{
    public class BookingCloneContext : DbContext
    {
        public BookingCloneContext(DbContextOptions<BookingCloneContext> options)
            : base(options)
        { }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Room> Rooms { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            // many to many 

            modelBuilder.Entity<Booking>()
                .HasOne(r => r.Agency)
                .WithMany(g => g.Bookings)
                .HasForeignKey(r => r.AgencyId);

            modelBuilder.Entity<Booking>()
                .HasOne(r => r.Guest)
                .WithMany(g => g.Bookings)
                .HasForeignKey(r => r.GuestId);
            
            modelBuilder.Entity<Booking>()
                .HasOne(r => r.Hotel)
                .WithMany(g => g.Bookings)
                .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<Booking>()
                .HasOne(r => r.Payment)
                .WithMany(g => g.Bookings)
                .HasForeignKey(r => r.PaymentId);

            modelBuilder.Entity<Booking>()
                .HasOne(r => r.Room)
                .WithMany(g => g.Bookings)
                .HasForeignKey(r => r.RoomId);


            modelBuilder.Entity<Agency>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<Guest>()
                .HasIndex(u => u.LastName);

            modelBuilder.Entity<Hotel>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.SoftDeleteSetup();

            modelBuilder.Seed();
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if(entry.Entity is BaseModel)
                {
                    var now = DateTime.UtcNow;
                    BaseModel entity = (BaseModel) entry.Entity;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entity.UpdatedAt = now;
                            break;
                        case EntityState.Added:
                            entity.CreatedAt = now;
                            break;
                    }
                }
            }
        }
    }
}