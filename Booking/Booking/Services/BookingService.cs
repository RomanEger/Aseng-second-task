using System.Linq.Expressions;
using Booking.Models;
using Booking.Models.Entities;
using Booking.Repository;

namespace Booking.Services;

public class BookingService(
    IUserRepository userRepository,
    IRoomRepository roomRepository,
    IDateWorkRepository dateWorkRepository,
    IBookedRoomRepository bookedRoomRepository,
    BookingDbContext context)
{
    private readonly BookingDbContext _dbContext = context;
    
    public async Task<User?> GetUserAsync(Expression<Func<User, bool>> expression)
    {
        return await userRepository.Get(expression);
    }

    public async Task<DateWork?> GetDateWorkAsync(Expression<Func<DateWork, bool>> expression)
    {
        return await dateWorkRepository.Get(expression);
    }

    public async Task<Room?> GetRoomAsync(Expression<Func<Room, bool>> expression)
    {
        return await roomRepository.Get(expression);
    }

    public async Task<Room?> GetRoomAsync(string hotelName, int roomNumber)
    {
        return await roomRepository.Get(hotelName, roomNumber);
    }
    
    public async Task<IEnumerable<AvailableRoomDto>> GetAvailableRoomsAsync()
    {
        return await dateWorkRepository.GetAll();
    }
    
    public async Task BookRoomAsync(BookedRoom bookedRoom)
    {
        await bookedRoomRepository.Create(bookedRoom);
        var dateWork = await dateWorkRepository.Get(x =>
            x.RoomId == bookedRoom.RoomId && x.Date == bookedRoom.BookedDate.ToUniversalTime().Date);
        if (dateWork is null)
            throw new Exception();
        dateWork.IsAvailable = false;
        //await dateWorkRepository.Update(dateWork);
    }

    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

}