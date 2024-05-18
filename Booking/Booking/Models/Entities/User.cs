using System.ComponentModel.DataAnnotations;

namespace Booking.Models.Entities;

public class User
{
    public Guid Id { get; set; }
    [MaxLength(70)]
    public string Name { get; set; } = null!;
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    [MaxLength(20)]
    public string PhoneNumber { get; set; } = null!;
}