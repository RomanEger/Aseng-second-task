using Booking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Models;

public class BookingDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Hotel> Hotels { get; set; } = null!;
    public DbSet<DateWork> DateWorks { get; set; } = null!;
    public DbSet<BookedRoom> BookedRooms { get; set; } = null!;

    public BookingDbContext()
    {
    }

    public BookingDbContext(DbContextOptions<BookingDbContext> options)
    : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasAlternateKey(x => x.PhoneNumber);

        modelBuilder.Entity<DateWork>()
            .HasAlternateKey(x => new {x.RoomId, x.Date});

        modelBuilder.Entity<Room>()
            .HasAlternateKey(x => new { x.Number, x.HotelId });

        modelBuilder.Entity<BookedRoom>()
            .HasAlternateKey(x => new { x.RoomId, x.UserId, x.StartDate });
    }
}