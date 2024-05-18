namespace Booking.Models.Entities;

public class DateWork
{
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    public DateTime Date { get; set; }
    public bool IsAvailable { get; set; }
    
    public Room Room { get; set; } = null!;
}