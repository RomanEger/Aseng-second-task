namespace Booking.Models;

public class AvailableRoomDto
{
    public string HotelName { get; set; } = null!;
    public int RoomNumber { get; set; }
    public DateTime AvailableDate { get; set; }
}