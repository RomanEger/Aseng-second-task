using System.Linq.Expressions;
using Booking.Models;
using Booking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository;

public class RoomRepository(BookingDbContext context) : IRoomRepository
{
    public async Task<Room?> Get(Expression<Func<Room, bool>> expression)
    {
        return await context.Set<Room>().FirstOrDefaultAsync(expression);
    }

    public async Task<Room?> Get(string hotelName, int roomNumber)
    {
        var room = await
        (
            from rooms in context.Rooms
            join hotel in context.Hotels
                on rooms.HotelId equals hotel.Id
            where rooms.Number == roomNumber && hotel.Name == hotelName
                select rooms
        ).FirstOrDefaultAsync();
        return room;
    }
}