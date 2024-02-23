using BUS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DAO
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomInformation> RoomInformations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookingReservation> BookingReservations { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomType>()
                .HasMany(rt => rt.RoomInformations)
                .WithOne(ri => ri.RoomType)
                .HasForeignKey(ri => ri.RoomTypeID);

            modelBuilder.Entity<RoomInformation>()
                .HasMany(ri => ri.BookingReservations)
                .WithOne(br => br.Room)
                .HasForeignKey(br => br.RoomID);

            modelBuilder.Entity<RoomInformation>()
                .HasMany(ri => ri.Reviews)
                .WithOne(r => r.Room)
                .HasForeignKey(r => r.RoomID);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.BookingReservations)
                .WithOne(br => br.Customer)
                .HasForeignKey(br => br.CustomerID);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Reviews)
                .WithOne(r => r.Customer)
                .HasForeignKey(r => r.CustomerID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                // Configure your database connection here
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-SGH8IOE\\SQLEXPRESS;Database=HotelDatabase;user=sa;password=1");
            }
        }
    }
}
