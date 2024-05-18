using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models.Entities;

public class DateWork
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    public DateTime Date { get; set; }
    public bool IsAvailable { get; set; }
    
    public Room Room { get; set; } = null!;
}