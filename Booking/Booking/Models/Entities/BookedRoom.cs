namespace Booking.Models.Entities;

public class BookedRoom
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid RoomId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public User User { get; set; } = null!;
    public Room Room { get; set; } = null!;
}