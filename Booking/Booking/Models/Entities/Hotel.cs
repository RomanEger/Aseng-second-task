using System.ComponentModel.DataAnnotations;

namespace Booking.Models.Entities;

public class Hotel
{
    public Guid Id { get; set; }
    [MaxLength(150)]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}