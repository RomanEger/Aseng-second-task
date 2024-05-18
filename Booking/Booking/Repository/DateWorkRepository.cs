using System.Linq.Expressions;
using Booking.Models;
using Booking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository;

public class DateWorkRepository(BookingDbContext context) : IDateWorkRepository
{
    public async Task<DateWork?> Get(Expression<Func<DateWork, bool>> expression)
    {
        return await context.Set<DateWork>().FirstOrDefaultAsync(expression);
    }

    public async Task<IEnumerable<AvailableRoomDto>> GetAll()
    {
        var list = await (
            from dateWork in context.DateWorks
            join room in context.Rooms
                on dateWork.RoomId equals room.Id
            join hotel in context.Hotels
                on room.HotelId equals hotel.Id
            where dateWork.IsAvailable
            select new AvailableRoomDto()
            {
                HotelName = hotel.Name,
                RoomNumber = room.Number,
                AvailableDate = dateWork.Date
            }
        ).ToListAsync();

        return list;
    }

    // public async Task Update(DateWork dateWork)
    // {
    //     //await Task.Run(() => context.DateWorks.Update(dateWork));
    //     var sql = $"UPDATE public.\"DateWorks\" SET \"IsAvailable\"=false WHERE \"Id\"='{dateWork.Id}'";
    //     await Task.Run(() => context.Database.ExecuteSqlRaw(sql));
    // }
}