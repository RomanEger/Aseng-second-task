namespace Booking.Models;

public class BookingRequestDto
{
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string HotelName { get; set; } = null!;
    public int RoomNumber { get; set; }
    public DateTime Date { get; set; }
}