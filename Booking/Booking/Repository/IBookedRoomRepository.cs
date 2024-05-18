using Booking.Models.Entities;

namespace Booking.Repository;

public interface IBookedRoomRepository
{
    Task Create(BookedRoom bookedRoom);
}