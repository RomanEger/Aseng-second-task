using Booking.Models;
using Booking.Models.Entities;

namespace Booking.Repository;

public class BookedRoomRepository(BookingDbContext context) : IBookedRoomRepository
{
    public async Task Create(BookedRoom bookedRoom)
    {
        await context.Set<BookedRoom>().AddAsync(bookedRoom);
    }
}