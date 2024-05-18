using System.Linq.Expressions;
using Booking.Models.Entities;

namespace Booking.Repository;

public interface IRoomRepository
{
    Task<Room?> Get(Expression<Func<Room, bool>> expression);

    Task<Room?> Get(string hotelName, int roomNumber);
}