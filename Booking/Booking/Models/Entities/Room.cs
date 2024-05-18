using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models.Entities;

public class Room
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public int Number { get; set; }
    
    public Hotel Hotel { get; set; } = null!;
}