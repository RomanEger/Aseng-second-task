namespace Booking.Models.Entities;

public class Room
{
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public int Number { get; set; }
    
    public Hotel Hotel { get; set; } = null!;
}