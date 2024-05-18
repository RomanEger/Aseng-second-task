using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models.Entities;

public class BookedRoom
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid RoomId { get; set; }
    public DateTime BookedDate { get; set; }
    
    public User User { get; set; } = null!;
    public Room Room { get; set; } = null!;
}